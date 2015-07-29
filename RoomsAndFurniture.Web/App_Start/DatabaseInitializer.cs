using System.IO;
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
        }

        public void Recreate()
        {
            File.Delete(DatabaseInfoKeeper.Main.FilePath);
            databaseCreator.Create(DatabaseInfoKeeper.Main.FilePath);
        }
    }
}