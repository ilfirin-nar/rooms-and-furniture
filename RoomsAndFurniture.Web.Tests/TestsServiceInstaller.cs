﻿using System.Reflection;
using LightInject;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Infrastructure.Database;
using RoomsAndFurniture.Web.Infrastructure.DependencyInjection;

namespace RoomsAndFurniture.Web.Tests
{
    public class TestsServiceInstaller
    {
        private static TestsServiceInstaller installer;
        private readonly ServiceContainer container;

        private static Assembly Assembly
        {
            get { return typeof(IService).Assembly; }
        }

        private TestsServiceInstaller()
        {
            container = new ServiceContainer();
        }

        public static ServiceContainer Install()
        {
            installer = new TestsServiceInstaller();
            installer.RegisterServices();
            return installer.container;
        }

        private void RegisterServices()
        {
            var lifetimeFactory = LifeTimeFactory.PerRequest;
            container.Register<IWebHandler>(Assembly, lifetimeFactory);
            container.Register<IClientDataMapper>(Assembly, lifetimeFactory);
            container.Register<IValidator>(Assembly, lifetimeFactory);
            container.Register<IService>(Assembly, lifetimeFactory);
            container.Register<IDao>(Assembly, lifetimeFactory);
            container.Register<IBusinessService>(Assembly, lifetimeFactory);
            container.Register<IQueryBuilder>((factory) => new QueryBuilder(factory));
            container.Register<IMainDbConectionFactory>(Assembly, LifeTimeFactory.PerContainer);
            container.Register<IQueryProceeder>(Assembly, LifeTimeFactory.PerContainer);
            container.Register<IQuery>(Assembly, LifeTimeFactory.PerContainer);
            container.Register<IService>(Assembly, LifeTimeFactory.PerContainer);
        }
    }
}