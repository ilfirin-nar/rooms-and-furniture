using System.Data.SQLite;

namespace RoomsAndFurniture.Web.Infrastructure.Extensions
{
    internal static class SqlConnectionExtensions
    {
        public static void ExecuteNonQueryCommand(this SQLiteConnection connection, string sql)
        {
            using (var command = new SQLiteCommand(sql, connection)) command.ExecuteNonQuery();
        }
    }
}