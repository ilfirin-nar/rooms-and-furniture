using System.Data;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureQueries
{
    public class UpdateFurnitureItemsQuery : IQuery<UpdateFurnitureItemsCriterion>
    {
        public void Proceed(IDbConnection connection, UpdateFurnitureItemsCriterion criterion)
        {
            connection.Execute(FurnitureQueriesSql.UpdateFurnitureQuery, criterion.FurnitureItems);
        }
    }
}