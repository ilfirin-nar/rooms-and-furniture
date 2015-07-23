using System;
using System.Reflection;
using LightInject;

namespace RoomsAndFurniture.Web.Infrastructure.DependencyInjection
{
    public static class ServiceRegistryExtensions
    {
        public static void Register<TInterface>(this IServiceRegistry serviceRegistry, Assembly assembly, Func<ILifetime> lifetimeFactory = null)
        {
            serviceRegistry.RegisterAssembly(assembly, lifetimeFactory ?? LifeTimeFactory.PerScope, ServiceRegistrationFilter.ShouldImplements<TInterface>);
        }
    }
}