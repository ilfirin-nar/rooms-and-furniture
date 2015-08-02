using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureLocations;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureLocations.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureLocations
{
    public class GetFurnitureLocationByRoomIdAndDateQuery : IQuery<GetFurnitureLocationByRoomIdAndDateCriterion, IList<FurnitureLocation>>
    {
        public IList<FurnitureLocation> Proceed(IDbConnection connection, GetFurnitureLocationByRoomIdAndDateCriterion criterion)
        {
            return connection.Query<FurnitureLocation>(FurnitureLocationsQuerySql.GetFurnitureLocationByRoomIdAndDateQuery, criterion).ToList();
        }
    }
}