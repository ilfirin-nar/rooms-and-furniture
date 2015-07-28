using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class IsExistAndEmptyRoomQuery : IQuery<IsExistAndEmptyRoomCriterion, bool>
    {
        public bool Proceed(IDbConnection connection, IsExistAndEmptyRoomCriterion criterion)
        {
            return connection.Query<int>(RoomQueriesSql.IsExistAndEmptyRoomQuery, criterion).Any();
        }
    }
}