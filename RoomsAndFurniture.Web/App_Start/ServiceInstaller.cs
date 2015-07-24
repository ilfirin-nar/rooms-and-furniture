using System.Reflection;
using LightInject;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
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

        public static void Install()
        {
            installer = new ServiceInstaller();
            installer.RegisterServices();
        }

        private void RegisterServices()
        {
            container.RegisterControllers();
            container.Register<IWebHandler>(ThisAssembly);
            container.Register<IClientDataMapper>(ThisAssembly);
            container.Register<IValidator>(ThisAssembly);
            container.Register<IService>(ThisAssembly);
            container.Register<IDao>(ThisAssembly);
            container.EnableMvc();
        }
    }
}