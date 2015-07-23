using System;
using System.Linq;

namespace RoomsAndFurniture.Web.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsImplements<TInterface>(this Type type)
        {
            var interfaceType = typeof (TInterface);
            return type.GetInterfaces().Any(it => it == interfaceType);
        }
    }
}