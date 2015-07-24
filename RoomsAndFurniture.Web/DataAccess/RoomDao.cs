using System.Data.SqlClient;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure;

namespace RoomsAndFurniture.Web.DataAccess
{
    internal class RoomDao : IRoomDao
    {
        public int Create(Room room)
        {

            using (var connection = new SqlConnection(ConnectionStringKeeper.RoomsAndFurniture))
            {
                const string sql = "insert into dbo.Room (CreateDate, Name) values (@CreateDate, @Name)";
                room.Id = connection.Execute(sql, room);
                return room.Id;
            }
        }

        public bool IsExists(string name)
        {
            using (var connection = new SqlConnection(ConnectionStringKeeper.RoomsAndFurniture))
            {
                const string sql = "select top 1 Id from dbo.Room where Name = @name";
                return connection.Query<Room>(sql, new {name}).Any();
            }
        }
    }
}