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
    public class GetFurnitureItemsByRoomsIdsAndDateQuery : IQuery<GetFurnitureItemsByRoomsIdsAndDateCriterion, IList<Furniture>>
    {
        public IList<Furniture> Proceed(IDbConnection connection, GetFurnitureItemsByRoomsIdsAndDateCriterion criterion)
        {
            return connection.Query<Furniture>(FurnitureQueriesSql.GetFurnitureItemsByRoomsIdsAndDateQuery, criterion).ToList();
        }
    }
}