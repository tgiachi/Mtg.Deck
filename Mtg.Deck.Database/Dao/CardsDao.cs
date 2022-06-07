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
    public class CardsDao : AbstractDataAccess<Guid, CardEntity, DeckDatabaseContext>
    {
        public CardsDao(IDbContextFactory<DeckDatabaseContext> dbContext, ILogger<CardEntity> logger) : base(dbContext, logger)
        {
        }

        public async Task<bool> CheckIfCardExists(string name)
        {
            var card = await QueryAsSingle(entities => entities.Where(s => s.CardName == name));

            return card != null;
        }

        public async Task<bool> IncrementQuantity(string cardName)
        {
            var card = await QueryAsSingle(entities => entities.Where(s => s.CardName == cardName));

            card.Quantity += 1;

            await Update(card);

            return true;
        }
    }
}
