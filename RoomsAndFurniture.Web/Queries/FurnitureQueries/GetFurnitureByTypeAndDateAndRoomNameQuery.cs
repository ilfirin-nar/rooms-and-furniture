using System.Data;
using System.Linq;
using Dapper;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Queries.FurnitureQueries.Sql;

namespace RoomsAndFurniture.Web.Queries.FurnitureQueries
{
    public class GetFurnitureByTypeAndDateAndRoomNameQuery
        : IQuery<GetFurnitureByTypeAndDateAndRoomNameCriterion, Furniture>
    {
        public Furniture Proceed(IDbConnection connection, GetFurnitureByTypeAndDateAndRoomNameCriterion criterion)
        {
            return connection
                .Query<Furniture>(FurnitureQueriesSql.GetFurnitureByTypeAndDateAndRoomNameQuery, criterion)
                .FirstOrDefault();
        }
    }
}