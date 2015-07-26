using System.Data;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class SaveRoomQuery : IQuery<SaveRoomCriterion, int>
    {
        public int Proceed(IDbConnection connection, SaveRoomCriterion criterion)
        {
            const string sql = "insert into Room (CreateDate, Name) values (@CreateDate, @Name)";
            criterion.Room.Id = connection.Execute(sql, criterion.Room);
            return criterion.Room.Id;
        }
    }
}