using System.Data;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Infrastructure.Database;

namespace RoomsAndFurniture.Web.Infrastructure
{
    public class MainDbSession : ISession
    {
        public MainDbSession(ISqliteConnectionFactory connectionFactory)
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