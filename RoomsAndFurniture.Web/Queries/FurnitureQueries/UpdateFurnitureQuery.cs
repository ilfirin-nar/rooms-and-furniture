using System.Data;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureQueries
{
    public class UpdateFurnitureQuery : IQuery<UpdateFurnitureCriterion, int>
    {
        public int Proceed(IDbConnection connection, UpdateFurnitureCriterion criterion)
        {
            connection.Execute(FurnitureQueriesSql.UpdateFurnitureQuery, criterion.Furniture);
            return criterion.Furniture.Id;
        }
    }
}