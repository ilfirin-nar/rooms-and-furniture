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

        void LogMoveFurnitureOut(DateTime date, string roomName, string roomTo, int count, Furniture furniture);

        void LogMoveFurnitureIn(DateTime date, string roomName, string roomFrom, int count, Furniture furniture);

        void LogMoveFurnitureItemsOut(DateTime date, string roomName, string roomTo, IList<Furniture> furnitureItems);

        void LogMoveFurnitureItemsIn(DateTime date, string roomName, string roomFrom, IList<Furniture> furnitureItems);
    }
}