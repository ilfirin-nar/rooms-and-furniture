using System;
using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureMover : IFurnitureMover 
    {
        private readonly IFurnitureReader reader;
        private readonly IFurnitureCreator creator;
        private readonly IFurnitureUpdater updater;
        private readonly IRoomReader roomReader;
        private readonly IRoomChecker roomChecker;
        private readonly IRoomEventLogger roomEventLogger;

        public FurnitureMover(
            IFurnitureReader reader,
            IFurnitureCreator creator,
            IFurnitureUpdater updater,
            IRoomReader roomReader,
            IRoomChecker roomChecker,
            IRoomEventLogger roomEventLogger)
        {
            this.reader = reader;
            this.creator = creator;
            this.updater = updater;
            this.roomReader = roomReader;
            this.roomChecker = roomChecker;
            this.roomEventLogger = roomEventLogger;
        }

        public Furniture Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            var furnitureFrom = reader.Get(type, roomNameFrom, date);
            CheckRooms(roomNameFrom, roomNameTo, date);
            var furnitureCount = furnitureFrom.Count;
            RemoveFurnitureFromFirstRoom(furnitureFrom, date);
            roomEventLogger.LogMoveFurnitureOut(date, roomNameTo, roomNameFrom, furnitureCount, furnitureFrom);
            var furnitureTo = reader.GetClosestLeftByDate(type, date, roomNameTo);
            var result = SetFurnitureToSecondRoom(furnitureFrom, furnitureTo, date, roomNameTo, furnitureCount);
            roomEventLogger.LogMoveFurnitureIn(date, roomNameTo, roomNameFrom, furnitureCount, result);
            return result;
        }

        private void CheckRooms(string roomNameFrom, string roomNameTo, DateTime date)
        {
            if (!roomChecker.IsExists(roomNameFrom, date))
            {
                throw new RoomNotFoundException(roomNameFrom, date);
            }
            if (!roomChecker.IsExists(roomNameTo, date))
            {
                throw new RoomNotFoundException(roomNameTo, date);
            }
        }

        private Furniture RemoveFurnitureFromFirstRoom(Furniture furnitureFrom, DateTime date)
        {
            if (furnitureFrom.Date.Date < date.Date)
            {
                return creator.Create(furnitureFrom.Type, date, furnitureFrom.RoomId, 0);
            }
            furnitureFrom.Date = date.Date;
            furnitureFrom.Count = 0;
            return updater.Update(furnitureFrom);
        }

        private Furniture SetFurnitureToSecondRoom(
            Furniture furnitureFrom, Furniture furnitureTo, DateTime date, string roomTo, int furnitureFromCount)
        {
            if (furnitureTo == null)
            {
                var roomId = roomReader.Get(roomTo, date).Id;
                return creator.Create(furnitureFrom.Type, date, roomId, furnitureFromCount);
            }
            var count = furnitureTo.Count + furnitureFromCount;
            if (furnitureTo.Date.Date < date.Date)
            {
                return creator.Create(furnitureTo.Type, date, furnitureTo.RoomId, count);
            }
            furnitureTo.Count = count;
            return updater.Update(furnitureFrom);
        }
    }
}