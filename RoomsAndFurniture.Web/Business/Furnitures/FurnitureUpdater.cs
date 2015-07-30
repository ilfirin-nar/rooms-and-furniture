using System.Collections.Generic;
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

        public FurnitureState Update(FurnitureState furnitureState)
        {
            var critreion = new UpdateFurnitureCriterion(furnitureState);
            queryBuilder.Query<UpdateFurnitureCriterion, int>().Proceed(critreion);
            return furnitureState;
        }

        public IList<FurnitureState> Update(IList<FurnitureState> furnitureItems)
        {
            var criterion = new UpdateFurnitureItemsCriterion(furnitureItems);
            queryBuilder.Command<UpdateFurnitureItemsCriterion>().Proceed(criterion);
            return furnitureItems;
        }
    }
}