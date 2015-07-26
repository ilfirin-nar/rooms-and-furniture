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
            container.Register<IWebHandler>(ThisAssembly);
            container.Register<IClientDataMapper>(ThisAssembly);
            container.Register<IValidator>(ThisAssembly);
            container.Register<IBusinessService>(ThisAssembly);
            container.Register<IQueryBuilder>((factory) => new QueryBuilder(factory));
            container.Register<IMainDbConectionFactory>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.Register<IQueryProceeder>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.Register<IQuery>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.Register<IService>(ThisAssembly, LifeTimeFactory.PerContainer);
            container.EnableMvc();
        }
    }
}