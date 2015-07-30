using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.RoomEvents
{
    public interface IRoomEventLogger : IBusinessService
    {
        void LogCreateRoom(Room room);

        void LogRemoveRoom(DateTime date, string roomName);

        void LogAddFurniture(DateTime date, string roomName, string typeName, int count);

        void LogMoveFurniture(DateTime date, string roomName, string roomTo, int count, FurnitureState furnitureState);

        void LogMoveFurnitureItems(DateTime date, string roomName, string roomTo, IList<FurnitureState> furnitureItems);
    }
}