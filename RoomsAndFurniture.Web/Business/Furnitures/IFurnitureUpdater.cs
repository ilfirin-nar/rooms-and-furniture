using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureUpdater : IBusinessService
    {
        FurnitureState Update(FurnitureState furnitureState);

        IList<FurnitureState> Update(IList<FurnitureState> furnitureItems);
    }
}