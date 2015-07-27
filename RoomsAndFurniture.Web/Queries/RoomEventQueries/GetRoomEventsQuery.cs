using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomEventsCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomEventQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomEventQueries
{
    public class GetRoomEventsQuery : IQuery<GetRoomEventsCriterion, IList<RoomEvent>>
    {
        public IList<RoomEvent> Proceed(IDbConnection connection, GetRoomEventsCriterion criterion)
        {
            var sql = criterion.IsShort
                ? RoomEventQueriesSql.GetShortRoomEventsQuery
                : RoomEventQueriesSql.GetRoomEventsQuery;
            return connection.Query<RoomEvent>(sql).ToList();
        }
    }
}