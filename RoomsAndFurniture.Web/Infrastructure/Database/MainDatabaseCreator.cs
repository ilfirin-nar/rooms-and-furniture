using System.Data.SQLite;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using queries = RoomsAndFurniture.Web.Queries.DatabaseInitialization.MainDbInitializationQueries;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    internal class MainDatabaseCreator : IDatabaseCreator
    {
        private readonly IMainDbConectionFactory connectionFactory;

        public MainDatabaseCreator(IMainDbConectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void Create(string databaseFileName)
        {
            SQLiteConnection.CreateFile(databaseFileName);
            using (var connection = connectionFactory.Create())
            {
                connection.Open();
                connection.ExecuteNonQueryCommand(queries.CreateMainDatabaseSql);
                connection.ExecuteNonQueryCommand(queries.InitialDataSql);
                connection.Close();
            }
        }
    }
}