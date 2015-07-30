using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureQueries
{
    public class GetFurnitureItemsByRoomIdAndDateAndTypesQuery
        : IQuery<GetFurnitureItemsByRoomIdAndDateAndTypesCriterion, IList<FurnitureState>>
    {
        public IList<FurnitureState> Proceed(IDbConnection connection, GetFurnitureItemsByRoomIdAndDateAndTypesCriterion criterion)
        {
            var sql = FurnitureQueriesSql.GetFurnitureItemsByRoomIdAndDateAndTypesQuery;
            return connection.Query<FurnitureState>(sql, criterion).ToList();
        }
    }
}