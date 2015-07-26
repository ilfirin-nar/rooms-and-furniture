using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class CreateFurnitureCriterion : ICriterion
    {
        public CreateFurnitureCriterion(Furniture furniture)
        {
            Furniture = furniture;
        }

        public Furniture Furniture { get; private set; } 
    }
}