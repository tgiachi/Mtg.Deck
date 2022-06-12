using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mtg.Deck.Database.Context;
using Mtg.Deck.Database.Entities;
using Mtg.Deck.Database.Impl.Dao;

namespace Mtg.Deck.Database.Dao
{
    public class RarityDao : AbstractDataAccess<Guid, RarityEntity, DeckDatabaseContext>
    {
        public RarityDao(IDbContextFactory<DeckDatabaseContext> dbContext, ILogger<RarityEntity> logger) : base(dbContext, logger)
        {
        }

        public async Task<RarityEntity> AddCardTypeIfNotExists(string type)
        {
            var exists = await QueryAsSingle(entities => entities.Where(s => s.Name == type));
            if (exists == null)
            {
                exists = await Insert(new RarityEntity {
                    Name = type
                });
            }

            return exists;
        }
    }
}
