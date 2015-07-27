using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class GetRoomsByDateQuery : IQuery<GetRoomsByDateCriterion, IList<Room>>
    {
        public IList<Room> Proceed(IDbConnection connection, GetRoomsByDateCriterion criterion)
        {
            return connection.Query<Room>(RoomQueriesSql.GetRoomsByDateQuery, criterion).ToList();
        }
    }
}