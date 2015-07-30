using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureReader : IBusinessService
    {
        FurnitureState GetClosestLeftByDate(string type, DateTime date, string roomName);

        FurnitureState Get(string type, string roomName, DateTime date);

        IList<FurnitureState> GetFurnitureItems(Room roomFrom, DateTime date);

        IList<FurnitureState> GetFurnitureItems(IList<string> furnitureTypes, Room room, DateTime date);

        IList<FurnitureState> Get(IList<int> roomsIds, DateTime date);
    }
}