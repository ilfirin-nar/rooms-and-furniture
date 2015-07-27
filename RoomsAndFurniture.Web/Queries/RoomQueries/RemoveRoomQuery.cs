using System.Data;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomQueries
{
    public class RemoveRoomQuery : IQuery<RemoveRoomCriterion, bool>
    {
        public bool Proceed(IDbConnection connection, RemoveRoomCriterion criterion)
        {
            return connection.Execute(RoomQueriesSql.RemoveRoomQuery, criterion.Room) == 1;
        }
    }
}