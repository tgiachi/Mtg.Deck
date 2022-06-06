using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Mtg.Deck.Api.Attributes;
using Mtg.Deck.Api.Utils;
using Serilog;
using Serilog.Extensions.Autofac.DependencyInjection;

namespace Mtg.Deck.Api.Manager
{
    public class MtgDeckManager
    {
        public IContainer Container { get => _container; }
        private IContainer _container;

        private ContainerBuilder _containerBuilder;

        public void Start()
        {
            _containerBuilder = new ContainerBuilder();
            _containerBuilder = _containerBuilder.RegisterSerilog("./");

            AssemblyUtils.GetAttribute<ModuleLoaderAttribute>().ForEach(s => {
                var module = Activator.CreateInstance(s) as IModule;
                _containerBuilder.RegisterModule(module);
            });

            _container = _containerBuilder.Build();
        }
    }
}
