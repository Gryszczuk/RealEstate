using Autofac;
using RealEstateScrapper.Services.Interfaces;
using System;

namespace RealEstateScrapper.Autofac.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IScrappingService).Assembly)
                .Where(t => typeof(IScrappingService).IsAssignableFrom(t))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IUrlGenerator<>)).AsImplementedInterfaces();
        }
    }
}
