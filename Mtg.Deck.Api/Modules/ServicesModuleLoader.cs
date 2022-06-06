using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Mtg.Deck.Api.Attributes;
using Mtg.Deck.Api.Services;
using ScryfallApi.Client;

namespace Mtg.Deck.Api.Modules
{

    [ModuleLoader]
    public class ServicesModuleLoader : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CardCastleCsvParser>().AsSelf();

            builder.Register(s => new ScryfallApiClient(
                new HttpClient() { BaseAddress = new Uri("https://api.scryfall.com/") },
                ScryfallApiClientConfig.GetDefault())).AsSelf();
            base.Load(builder);
        }
    }
}
