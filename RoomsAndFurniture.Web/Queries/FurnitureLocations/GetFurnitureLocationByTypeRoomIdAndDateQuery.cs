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
    public class GetFurnitureLocationByTypeRoomIdAndDateQuery : IQuery<GetFurnitureLocationByTypeRoomIdAndDateCriterion, IList<FurnitureLocation>>
    {
        public IList<FurnitureLocation> Proceed(IDbConnection connection, GetFurnitureLocationByTypeRoomIdAndDateCriterion criterion)
        {
            return connection.Query<FurnitureLocation>(FurnitureLocationsQuerySql.GetFurnitureLocationByTypeRoomIdAndDateQuery, criterion).ToList();
        }
    }
}