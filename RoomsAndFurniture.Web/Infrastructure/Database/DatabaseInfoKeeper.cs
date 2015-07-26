using System.Web.Configuration;
using System.Web.Hosting;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    internal static class DatabaseInfoKeeper
    {
        static DatabaseInfoKeeper()
        {
            var databaseName = WebConfigurationManager.AppSettings["DatabaseName"];
            var filePath = string.Format("{0}{1}.sqlite", HostingEnvironment.ApplicationPhysicalPath, databaseName);
            var connectionString = string.Format("Data Source={0};Version=3;", filePath);
            Main = new DatabaseInfo(databaseName, filePath, connectionString);
        }

        public static DatabaseInfo Main { get; private set; }

        internal class DatabaseInfo
        {
            public DatabaseInfo(string name, string filePath, string connectionString)
            {
                Name = name;
                FilePath = filePath;
                ConnectionString = connectionString;
            }

            public string Name { get; set; }

            public string FilePath { get; set; }

            public string ConnectionString { get; set; }
        }
    }
}