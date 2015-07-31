using System.Data;

namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IDbConnectionFactory : IService {}

    public interface IDbConnectionFactory<out T> : IDbConnectionFactory where T : IDbConnection
    {
        T Create();
    }
}