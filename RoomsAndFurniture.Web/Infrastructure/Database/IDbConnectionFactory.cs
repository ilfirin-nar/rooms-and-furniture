using System.Data;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    public interface IDbConnectionFactory<out T> : IService
        where T : IDbConnection
    {
        T Create();
    }
}