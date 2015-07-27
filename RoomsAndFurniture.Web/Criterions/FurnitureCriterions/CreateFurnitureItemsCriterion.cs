using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class CreateFurnitureItemsCriterion : ICriterion
    {
        public CreateFurnitureItemsCriterion(IList<Furniture> furnitureItems)
        {
            FurnitureItems = furnitureItems;
        }

        public IList<Furniture> FurnitureItems { get; private set; } 
    }
}