using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class IsRoomExistsQuery : IQuery<IsRoomExistsCriterion, bool>
    {
        public bool Proceed(IDbConnection connection, IsRoomExistsCriterion criterion)
        {
            return connection.Query<int>(RoomQueriesSql.IsRoomExistsQuery, criterion).Any();
        }
    }
}