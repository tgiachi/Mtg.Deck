using System;
using System.Collections.Concurrent;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dasync.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mtg.Deck.Api.Data;
using Mtg.Deck.Api.Manager;
using Mtg.Deck.Api.Modules;
using Mtg.Deck.Api.Services;
using Mtg.Deck.Api.Utils;
using Mtg.Deck.Database.Context;
using Mtg.Deck.Database.Dao;
using Mtg.Deck.Database.Entities;
using ScryfallApi.Client;
using ScryfallApi.Client.Models;

namespace Mtg.Deck.Parser // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static MtgDeckManager _manager;
        static AutofacServiceProvider _serviceProvider;
        async static Task Main(string[] args)
        {
            AssemblyUtils.AddAssembly(typeof(ServicesModuleLoader).Assembly);
            AssemblyUtils.AddAssembly(typeof(DeckDatabaseContext).Assembly);

            _manager = new MtgDeckManager();
            var builder = _manager.Start();

            var serviceCollection = new ServiceCollection();


            serviceCollection.AddLogging();
            serviceCollection.AddDbContextFactory<DeckDatabaseContext>(optionsBuilder => {
                optionsBuilder.UseSqlite(@"DataSource=C:\TEMP\cards.db;");
            });


            builder.Populate(serviceCollection);
            var container = builder.Build();
            _serviceProvider = new AutofacServiceProvider(container);


            await EnsureMigrations();

            Console.WriteLine("Insert CardCastle filename:");
            var path = Console.ReadLine();

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("!!! Path can't be null !!!");
                return;
            }


            var parser = _serviceProvider.GetService<CardCastleCsvParser>();
            var records = parser.ParseCsv(path);

            var cards = await SearchCard(records);
            Console.WriteLine("Adding colors");
            await AddColors(cards);
            Console.WriteLine("Adding card types");
            await AddCardType(cards);
            Console.WriteLine("Adding cards");
            await AddCards(cards);
            Console.ReadKey();
        }

        private static async Task EnsureMigrations()
        {
            var dbContext = _serviceProvider.GetService<DeckDatabaseContext>();

            if ((await dbContext.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                await dbContext.Database.MigrateAsync();
            }
        }

        private static async Task<List<Card>> SearchCard(List<CardCastleRecord> records)
        {
            var res = new ConcurrentBag<Card>();
            var client = _serviceProvider.GetService<ScryfallApiClient>();


            await records.ParallelForEachAsync(async (record, i) => {
                if (string.IsNullOrEmpty(record.Name)) return;

                if (record.Name.Contains("//"))
                {
                    record.Name = record.Name.Split("//")[0];
                }

                try
                {
                    Console.WriteLine($"Searching {i}/{records.Count} - {record.Name}");
                    var result = await client.Cards.Search(record.Name, 1, SearchOptions.CardSort.Name);
                    var card = result.Data.FirstOrDefault();
                    if (card != null)
                    {
                        if (card.Name == record.Name)
                        {
                            res.Add(card);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {ex}");
                }

            }, 10);
            return res.ToList();
        }

        public static async Task AddColors(List<Card> cards)
        {
            var colorsDao = _serviceProvider.GetService<ColorsDao>();

            var colors = cards.DistinctBy(s => s.Colors).Select(s => s.Colors).ToList();

            foreach (var color in colors)
            {
                foreach (var c in color)
                {
                    if (!string.IsNullOrEmpty(c))
                    {
                        await colorsDao.AddIfNotExists(c);
                    }
                }
            }

        }

        public static async Task AddCardType(List<Card> cards)
        {
            var cardTypeDao = _serviceProvider.GetService<CardTypeDao>();

            var types = cards.DistinctBy(s => s.TypeLine).Select(s => s.TypeLine.Split('—')[0].Trim()).DistinctBy(s => s).Select(s => s).ToList();

            foreach (var type in types)
            {
                await cardTypeDao.AddCardTypeIfNotExists(type);
            }
        }

        public static async Task AddCards(List<Card> cards)
        {

            var cardDao = _serviceProvider.GetService<CardsDao>();
            var colorsDao = _serviceProvider.GetService<ColorsDao>();
            var cardTypeDao = _serviceProvider.GetService<CardTypeDao>();



            foreach (var card in cards)
            {
                var mana = TokenUtils.ExtractManaToken(card.ManaCost);
                var type = card.TypeLine.Split('—')[0].Trim();

                Console.WriteLine($"{card.Name} - {card.ManaCost} - total: {mana}");
                var exists = await cardDao.CheckIfCardExists(card.Name);

                if (exists)
                {
                    await cardDao.IncrementQuantity(card.Name);
                }
                else
                {
                    var colors = new List<ColorEntity>();
                    foreach (var color in card.Colors)
                    {
                        colors.Add(await colorsDao.QueryAsSingle(entities => entities.Where(s => s.Name == color)));
                    }

                    var cardType = await cardTypeDao.QueryAsSingle(entities => entities.Where(s => s.CardType == type));

                    await cardDao.Insert(new CardEntity() {
                        CardName = card.Name,
                        Colors = colors,
                        CardType = cardType,
                        ManaCost = card.ManaCost,
                        TotalManaCosts = mana,
                        Quantity = 1,
                        ImageUrl = card.ImageUris["small"].ToString(),
                        Price = card.Prices.Eur,
                        MtgId = card.MtgoId,
                    });
                }
            }
        }
    }
}