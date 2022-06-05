using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Mtg.Deck.Api.Data;

namespace Mtg.Deck.Api.Services
{
    public class CardCastleCsvParser
    {
        public List<CardCastleRecord> ParseCsv(string fileName)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            using var reader = new StreamReader(fileName);
            using var csv = new CsvReader(reader, config);
            return csv.GetRecords<CardCastleRecord>().ToList();
        }
    }
}
