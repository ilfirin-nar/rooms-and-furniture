using System.Data;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Infrastructure.Database;

namespace RoomsAndFurniture.Web.Infrastructure
{
    public class SqliteSession : ISession
    {
        public SqliteSession(ISqliteConnectionFactory connectionFactory)
        {
            Connection = connectionFactory.Create();
            Connection.Open();
        }

        public IDbConnection Connection { get; private set; }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}