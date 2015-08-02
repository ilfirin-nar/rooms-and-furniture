using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureReader : IBusinessService
    {
        Furniture Get(string type, int roomId, DateTime date);

        IList<FurnitureState> Get(IList<int> roomsIds, DateTime date);
    }
}