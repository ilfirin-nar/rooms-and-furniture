using System.Data.SQLite;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    internal class MainDbConnectionFactory : IMainDbConectionFactory
    {
        public SQLiteConnection Create()
        {
            return new SQLiteConnection(DatabaseInfoKeeper.Main.ConnectionString);
        }
    }
}