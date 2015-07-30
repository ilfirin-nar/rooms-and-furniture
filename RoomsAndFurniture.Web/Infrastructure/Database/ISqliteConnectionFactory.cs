using System.Data.SQLite;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    public interface ISqliteConnectionFactory : IDbConnectionFactory<SQLiteConnection> {}
}