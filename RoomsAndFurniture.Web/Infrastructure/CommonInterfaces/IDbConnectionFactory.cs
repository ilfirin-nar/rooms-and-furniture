using System.Data;

namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IDbConnectionFactory<out T> : IService
        where T : IDbConnection
    {
        T Create();
    }
}