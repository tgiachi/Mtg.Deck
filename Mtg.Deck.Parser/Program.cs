using System;
using System.Collections.Concurrent;
using Autofac;
using Dasync.Collections;
using Microsoft.EntityFrameworkCore;
using Mtg.Deck.Api.Data;
using Mtg.Deck.Api.Manager;
using Mtg.Deck.Api.Modules;
using Mtg.Deck.Api.Services;
using Mtg.Deck.Api.Utils;
using Mtg.Deck.Database.Context;
using Mtg.Deck.Database.Dao;
using ScryfallApi.Client;
using ScryfallApi.Client.Models;

namespace Mtg.Deck.Parser // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static MtgDeckManager _manager;
        async static Task Main(string[] args)
        {
            AssemblyUtils.AddAssembly(typeof(ServicesModuleLoader).Assembly);
            AssemblyUtils.AddAssembly(typeof(DeckDatabaseContext).Assembly);

            _manager = new MtgDeckManager();
            _manager.Start();

            await EnsureMigrations();

            Console.WriteLine("Insert CardCastle filename:");
            var path = Console.ReadLine();

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("!!! Path can't be null !!!");
                return;
            }


            var parser = _manager.Container.Resolve<CardCastleCsvParser>();
            var records = parser.ParseCsv(path);

            var cards = await SearchCard(records);
            await AddColors(cards);
            Console.ReadKey();
        }

        private static async Task EnsureMigrations()
        {
            var dbContext = _manager.Container.Resolve<DeckDatabaseContext>();

            //if ((await dbContext.Database.GetPendingMigrationsAsync()).Count() > 0)
            //{
            //    await dbContext.Database.MigrateAsync();
            //}
        }

        private static async Task<List<Card>> SearchCard(List<CardCastleRecord> records)
        {
            var res = new ConcurrentBag<Card>();
            var client = _manager.Container.Resolve<ScryfallApiClient>();


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
            var colorsDao = _manager.Container.Resolve<ColorsDao>();

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
    }
}