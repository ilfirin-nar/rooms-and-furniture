using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureReader : IBusinessService
    {
        Furniture GetClosestLeftByDate(string type, DateTime date, string roomName);

        Furniture Get(string type, string roomName, DateTime date);

        IList<Furniture> GetFurnitureItems(Room roomFrom, DateTime date);

        IList<Furniture> GetFurnitureItems(IList<string> furnitureTypes, Room room, DateTime date);

        IList<Furniture> Get(IList<int> roomsIds, DateTime date);
    }
}