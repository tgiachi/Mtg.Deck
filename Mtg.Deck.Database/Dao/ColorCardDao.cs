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
    public class ColorCardDao : AbstractDataAccess<Guid, ColorCardEntity, DeckDatabaseContext>
    {
        public ColorCardDao(IDbContextFactory<DeckDatabaseContext> dbContext, ILogger<ColorCardEntity> logger) : base(dbContext, logger)
        {
        }
    }
}
