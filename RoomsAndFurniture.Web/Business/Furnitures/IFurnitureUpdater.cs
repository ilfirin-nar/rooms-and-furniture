using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureUpdater : IBusinessService
    {
        Furniture Update(Furniture furniture);

        IList<Furniture> Update(IList<Furniture> furnitureItems);
    }
}