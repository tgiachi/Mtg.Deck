using System;
using System.Collections.Concurrent;
using Dasync.Collections;
using Mtg.Deck.Api.Data;
using Mtg.Deck.Api.Services;
using ScryfallApi.Client;
using ScryfallApi.Client.Models;

namespace Mtg.Deck.Parser // Note: actual namespace depends on the project name.
{
    public class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var parser = new CardCastleCsvParser();
            var records = parser.ParseCsv(@"c:\temp\export_cardcastle_1654422660.csv");

            var cards = await SearchCard(records);
            Console.ReadKey();
        }

        private static async Task<List<Card>> SearchCard(List<CardCastleRecord> records)
        {
            var res = new ConcurrentBag<Card>();
            var client = new ScryfallApiClient(new HttpClient() { BaseAddress = new Uri("https://api.scryfall.com/") },
                ScryfallApiClientConfig.GetDefault());


            await records.ParallelForEachAsync(async (record, i) =>
              {
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
    }
}