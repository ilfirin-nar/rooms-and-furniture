using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class UpdateFurnitureItemsCriterion : ICriterion
    {
        public UpdateFurnitureItemsCriterion(IList<FurnitureState> furnitureItems)
        {
            FurnitureItems = furnitureItems;
        }

        public IList<FurnitureState> FurnitureItems { get; private set; } 
    }
}