using System.Data;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureQueries
{
    public class CreateFurnitureItemsQuery : IQuery<CreateFurnitureItemsCriterion>
    {
        public void Proceed(IDbConnection connection, CreateFurnitureItemsCriterion criterion)
        {
            connection.Execute(FurnitureQueriesSql.CreateFurnitureQuery, criterion.FurnitureItems);
        }
    }
}