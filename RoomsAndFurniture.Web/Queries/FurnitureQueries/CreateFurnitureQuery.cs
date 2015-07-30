using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureQueries
{
    public class CreateFurnitureQuery : IQuery<CreateFurnitureCriterion, int>
    {
        public int Proceed(IDbConnection connection, CreateFurnitureCriterion criterion)
        {
            criterion.FurnitureState.Id = connection.Query<int>(FurnitureQueriesSql.CreateFurnitureQuery, criterion.FurnitureState).FirstOrDefault();
            return criterion.FurnitureState.Id;
        }
    }
}