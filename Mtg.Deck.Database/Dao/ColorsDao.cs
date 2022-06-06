using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Mtg.Deck.Database.Context;
using Mtg.Deck.Database.Entities;
using Mtg.Deck.Database.Impl.Dao;
using Serilog;

namespace Mtg.Deck.Database.Dao
{
    public class ColorsDao : AbstractDataAccess<Guid, ColorEntity, DeckDatabaseContext>
    {
        public ColorsDao(DeckDatabaseContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public async Task<ColorEntity> AddIfNotExists(string color)
        {
            var colorEntity = await QueryAsSingle(s => s.Where(k => k.Name == color));
            if (colorEntity == null)
            {
                colorEntity = new ColorEntity() {
                    Name = color
                };
            }

            return colorEntity;
        }
    }
}
