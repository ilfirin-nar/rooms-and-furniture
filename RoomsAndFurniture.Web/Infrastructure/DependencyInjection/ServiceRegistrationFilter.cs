using System;
using RoomsAndFurniture.Web.Infrastructure.Extensions;

namespace RoomsAndFurniture.Web.Infrastructure.DependencyInjection
{
    public static class ServiceRegistrationFilter
    {
        public static bool ShouldImplements<TInterface>(Type interfaceType, Type implementingType)
        {
            var type = typeof(TInterface);
            return (interfaceType == type || interfaceType.IsImplements<TInterface>()) && 
                implementingType.IsImplements<TInterface>();
        }
    }
}