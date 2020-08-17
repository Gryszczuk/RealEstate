//using Autofac;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RealEstateScrapper.Autofac.Modules
//{
//    public class MapperModule : Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            //register all profile classes in the calling assembly
//            builder.RegisterAssemblyTypes(typeof(MapperModule).Assembly).As<Profile>();

//            builder.Register(context => new MapperConfiguration(cfg =>
//            {
//                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
//                {
//                    cfg.AddProfile(profile);
//                }
//            })).AsSelf().SingleInstance();

//            builder.Register(c =>
//            {
//                //This resolves a new context that can be used later.
//                var context = c.Resolve<IComponentContext>();
//                var config = context.Resolve<MapperConfiguration>();
//                return config.CreateMapper(context.Resolve);
//            })
//                .As<IMapper>()
//                .InstancePerLifetimeScope();

//            builder.RegisterAssemblyTypes(typeof(MapperModule).Assembly)
//                .AsClosedTypesOf(typeof(ITypeConverter<,>))
//                .AsSelf();
//        }
//    }
//}
