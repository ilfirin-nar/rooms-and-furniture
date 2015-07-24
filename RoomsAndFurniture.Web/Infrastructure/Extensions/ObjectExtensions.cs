using Omu.ValueInjecter;

namespace RoomsAndFurniture.Web.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static T MapTo<T>(this object obj) where T : new()
        {
            var result = new T();
            result.InjectFrom(obj);
            return result;
        }
    }
}