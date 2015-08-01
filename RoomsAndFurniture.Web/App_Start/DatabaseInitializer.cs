using System.IO;
using DapperExtensions.Sql;
using RoomsAndFurniture.Web.Infrastructure.Database;

namespace RoomsAndFurniture.Web
{
    internal class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IDatabaseCreator databaseCreator;

        public DatabaseInitializer(IDatabaseCreator databaseCreator)
        {
            this.databaseCreator = databaseCreator;
        }

        public void Initialize()
        {
            if (!File.Exists(DatabaseInfoKeeper.Main.FilePath))
            {
                databaseCreator.Create(DatabaseInfoKeeper.Main.FilePath);
            }
            SetupSqliteDialect();
        }

        public void Recreate()
        {
            File.Delete(DatabaseInfoKeeper.Main.FilePath);
            databaseCreator.Create(DatabaseInfoKeeper.Main.FilePath);
        }

        private static void SetupSqliteDialect()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();
        }
    }
}