using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class CreateFurnitureCriterion : ICriterion
    {
        public CreateFurnitureCriterion(FurnitureState furnitureState)
        {
            FurnitureState = furnitureState;
        }

        public FurnitureState FurnitureState { get; private set; } 
    }
}