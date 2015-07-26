using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class GetRoomByNameAndDateQuery : IQuery<GetRoomByNameAndDateCriterion, Room>
    {
        public Room Proceed(IDbConnection connection, GetRoomByNameAndDateCriterion criterion)
        {
            var sql = RoomQueriesSql.GetRoomByNameAndDateCriterionQuery;
            return connection.Query<Room>(sql, criterion).FirstOrDefault();
        }
    }
}