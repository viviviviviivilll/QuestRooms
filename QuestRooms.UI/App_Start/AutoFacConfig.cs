using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using QuestRooms.BLL.Mapping;
using QuestRooms.BLL.Services.Abstraction;
using QuestRooms.BLL.Services.Implementation;
using QuestRooms.DAL;
using QuestRooms.DAL.Entities;
using QuestRooms.DAL.Interfaces;
using QuestRooms.DAL.Repositiries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.App_Start
{
    public class AutoFacConfig
    {
        public static void ConfigureAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            RegisterTypes(builder);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

        }
        private static void RegisterTypes(ContainerBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            Mapper mapper = new Mapper(mapperConfig);
            builder.RegisterInstance(mapper).As<IMapper>();

            builder.RegisterType<RoomsContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<CityService>().As<ICityService>();
        }
    }
}