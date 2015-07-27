using System.Data;
using Dapper;
using RoomsAndFurniture.Web.Criterions.RoomEventsCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.RoomEventQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.RoomEventQueries
{
    public class SaveRoomEventQuery : IQuery<SaveRoomEventCriterion>
    {
        public void Proceed(IDbConnection connection, SaveRoomEventCriterion criterion)
        {
            connection.Execute(RoomEventQueriesSql.SaveRoomEventQuery, criterion.RoomEvent);
        }
    }
}