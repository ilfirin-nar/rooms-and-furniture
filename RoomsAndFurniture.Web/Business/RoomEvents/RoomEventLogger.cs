using System;
using System.Collections.Generic;
using System.Linq;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Enums;

namespace RoomsAndFurniture.Web.Business.RoomEvents
{
    internal class RoomEventLogger : IRoomEventLogger
    {
        private readonly IRoomEventSaver saver;

        public RoomEventLogger(IRoomEventSaver saver)
        {
            this.saver = saver;
        }

        public void LogCreateRoom(Room room)
        {
            var descripton = string.Format(RoomEventMessage.RoomWasCreated, room.Name);
            var roomEvent = new RoomEvent(room.CreateDate, RoomEventType.CreateRoom, descripton);
            saver.Save(roomEvent);
        }

        public void LogRemoveRoom(DateTime date, string roomName)
        {
            var descripton = string.Format(RoomEventMessage.RoomWasRemoved, roomName);
            var roomEvent = new RoomEvent(date, RoomEventType.RemoveRoom, descripton);
            saver.Save(roomEvent);
        }

        public void LogAddFurniture(DateTime date, string roomName, string typeName, int count)
        {
            var furnitureDescription = string.Format(RoomEventMessage.FurnitureTemplate, typeName, count);
            var descripton = string.Format(RoomEventMessage.FurnitureWasAdded, furnitureDescription, roomName);
            var roomEvent = new RoomEvent(date, RoomEventType.AddFurniture, descripton);
            saver.Save(roomEvent);
        }

        public void LogMoveFurniture(DateTime date, string roomName, string roomTo, int count, Furniture furniture)
        {
            var furnitureDescription = string.Format(RoomEventMessage.FurnitureTemplate, furniture.Type, count);
            var descripton = string.Format(RoomEventMessage.FurnitureWasMoved, furnitureDescription, roomName, roomTo);
            var roomEvent = new RoomEvent(date, RoomEventType.MoveFurnitureOut, descripton);
            saver.Save(roomEvent);
        }

        public void LogMoveFurnitureItems(DateTime date, string roomName, string roomTo, IList<Furniture> furnitureItems)
        {
            var furnitureDescription = GetFurnitureItemsString(furnitureItems);
            var descripton = string.Format(RoomEventMessage.FurnitureWasMoved, furnitureDescription, roomName, roomTo);
            var roomEvent = new RoomEvent(date, RoomEventType.MoveFurnitureIn, descripton);
            saver.Save(roomEvent);
        }

        private static string GetFurnitureItemsString(IEnumerable<Furniture> furnitureItems)
        {
            var strings = furnitureItems.Select(f => string.Format(RoomEventMessage.FurnitureTemplate, f.Type, f.Count)).ToList();
            return string.Join(", ", strings);
        }
    }
}