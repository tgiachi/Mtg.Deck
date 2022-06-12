using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Mtg.Deck.Api.Attributes;
using Mtg.Deck.Database.Context;
using Mtg.Deck.Database.Dao;

namespace Mtg.Deck.Database.Modules
{

    [ModuleLoader]
    public class DatabaseModuleLoader : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => {
                var optionsBuilder = new DbContextOptionsBuilder<DeckDatabaseContext>();
                optionsBuilder.UseSqlite(@"DataSource=cards.db;");

                return new DeckDatabaseContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();



            builder.RegisterType<ColorsDao>().AsSelf();
            builder.RegisterType<CardsDao>().AsSelf();
            builder.RegisterType<CardTypeDao>().AsSelf();
            builder.RegisterType<ColorCardDao>().AsSelf();
            builder.RegisterType<RarityDao>().AsSelf();
            base.Load(builder);
        }
    }
}
