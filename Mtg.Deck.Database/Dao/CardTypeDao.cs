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
    public class CardTypeDao : AbstractDataAccess<Guid, CardTypeEntity, DeckDatabaseContext>
    {
        public CardTypeDao(DeckDatabaseContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
