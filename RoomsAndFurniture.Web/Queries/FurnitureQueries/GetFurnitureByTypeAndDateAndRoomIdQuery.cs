using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureQueries
{
    public class GetFurnitureByTypeAndDateAndRoomIdQuery
        : IQuery<GetFurnitureByTypeAndDateAndRoomIdCriterion, Furniture>
    {
        public Furniture Proceed(IDbConnection connection, GetFurnitureByTypeAndDateAndRoomIdCriterion criterion)
        {
            return connection
                .Query<Furniture>(FurnitureQueriesSql.GetFurnitureByTypeAndDateAndRoomIdQuery, criterion)
                .FirstOrDefault();
        }
    }
}