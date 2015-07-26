using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureUpdater : IFurnitureUpdater
    {
        private readonly IQueryBuilder queryBuilder;

        public FurnitureUpdater(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public Furniture Update(Furniture furniture)
        {
            var critreion = new UpdateFurnitureCriterion(furniture);
            queryBuilder.Query<UpdateFurnitureCriterion, int>().Proceed(critreion);
            return furniture;
        }
    }
}