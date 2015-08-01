using System.Reflection;
using LightInject;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Infrastructure.Database;
using RoomsAndFurniture.Web.Infrastructure.DependencyInjection;

namespace RoomsAndFurniture.Web
{
    public class ServiceInstaller
    {
        private static ServiceInstaller installer;
        private readonly ServiceContainer container;

        private Assembly ThisAssembly
        {
            get { return GetType().Assembly; }
        }

        private ServiceInstaller()
        {
            container = new ServiceContainer();
        }

        public static IServiceContainer Install()
        {
            installer = new ServiceInstaller();
            installer.RegisterServices();
            return installer.container;
        }

        private void RegisterServices()
        {
            container.RegisterControllers();
            container.Register<ISqliteConnectionFactory>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.Register<IDatabaseCreator>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.Register<IDatabaseInitializer>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.Register<IQueryExecuter>(ThisAssembly);
            container.Register<IQueryProceeder>(ThisAssembly);
            container.Register<IQuery>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.Register<IQueryBuilder>(factory => new QueryBuilder(factory));
            container.Register<ISession>(ThisAssembly);
            container.Register<IRepository>(ThisAssembly);
            container.Register<IBusinessService>(ThisAssembly);
            container.Register<IClientDataMapper>(ThisAssembly);
            container.Register<IValidator>(ThisAssembly);
            container.Register<IWebHandler>(ThisAssembly);
            container.EnableMvc();
        }
    }
}