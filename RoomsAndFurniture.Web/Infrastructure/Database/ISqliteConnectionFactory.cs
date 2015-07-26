using System.Data.SQLite;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    public interface ISqliteConnectionFactory : IDbConnectionFactory<SQLiteConnection> {}
}