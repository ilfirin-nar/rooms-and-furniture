using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class CreateRoomQuery : IQuery<CreateRoomCriterion, int>
    {
        public int Proceed(IDbConnection connection, CreateRoomCriterion criterion)
        {
            criterion.Room.Id = connection.Query<int>(RoomQueriesSql.CreateRoomQuery, criterion.Room).FirstOrDefault();
            return criterion.Room.Id;
        }
    }
}