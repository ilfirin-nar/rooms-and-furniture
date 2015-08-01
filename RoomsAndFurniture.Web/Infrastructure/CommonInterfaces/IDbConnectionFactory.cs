using System.Data;

namespace RoomsAndFurniture.Web.Infrastructure.CommonInterfaces
{
    public interface IDbConnectionFactory {}

    public interface IDbConnectionFactory<out T> : IDbConnectionFactory where T : IDbConnection
    {
        T Create();
    }
}