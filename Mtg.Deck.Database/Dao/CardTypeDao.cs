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
using Serilog;

namespace Mtg.Deck.Database.Dao
{
    public class CardTypeDao : AbstractDataAccess<Guid, CardTypeEntity, DeckDatabaseContext>
    {
        public CardTypeDao(IDbContextFactory<DeckDatabaseContext> dbContext, ILogger<CardTypeEntity> logger) : base(dbContext, logger)
        {
        }

        public async Task<CardTypeEntity> AddCardTypeIfNotExists(string type)
        {
            var exists = await QueryAsSingle(entities => entities.Where(s => s.CardType == type));
            if (exists == null)
            {
                exists = await Insert(new CardTypeEntity {
                    CardType = type
                });
            }

            return exists;
        }
    }
}
