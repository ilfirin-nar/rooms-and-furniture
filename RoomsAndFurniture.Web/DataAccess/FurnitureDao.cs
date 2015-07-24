using System.Data.SqlClient;
using Dapper;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure;

namespace RoomsAndFurniture.Web.DataAccess
{
    internal class FurnitureDao : IFurnitureDao
    {
        public int Save(Furniture furniture)
        {
            using (var connection = new SqlConnection(ConnectionStringKeeper.RoomsAndFurniture))
            {
                const string sql = "insert into dbo.Furniture (Type, Count, RoomId) values (@Type, @Count, @RoomId)";
                furniture.Id = connection.Execute(sql, furniture);
                return furniture.Id;
            }
        }
    }
}