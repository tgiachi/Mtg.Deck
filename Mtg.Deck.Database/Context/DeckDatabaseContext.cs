using Microsoft.EntityFrameworkCore;
using Mtg.Deck.Database.Entities;

namespace Mtg.Deck.Database.Context
{
    public class DeckDatabaseContext : DbContext
    {
        public DbSet<CardEntity> Cards { get; set; }
        public DbSet<ColorEntity> Colors { get; set; }
        public DbSet<CardTypeEntity> CardTypes { get; set; }

        public DeckDatabaseContext()
        {

        }

        public DeckDatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=cards.db;");
        }
    }
}
