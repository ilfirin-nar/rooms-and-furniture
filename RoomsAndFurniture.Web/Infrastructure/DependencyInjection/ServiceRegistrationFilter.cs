using System;
using RoomsAndFurniture.Web.Infrastructure.Extensions;

namespace RoomsAndFurniture.Web.Infrastructure.DependencyInjection
{
    public static class ServiceRegistrationFilter
    {
        public static bool ShouldImplements<TInterface>(Type interfaceType, Type implementingType)
        {
            return interfaceType.IsImplements<TInterface>() && implementingType.IsImplements<TInterface>();
        }
    }
}