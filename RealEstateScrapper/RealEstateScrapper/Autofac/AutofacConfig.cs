using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateScrapper.Autofac
{
    public class AutofacConfig
    {
        public static IContainer Configure(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(AutofacConfig).Assembly);

            builder.Populate(services);
            var container = builder.Build();
            return container;
        }
    }
}
