using System;
using RoomsAndFurniture.Web.Business.Furnitures.Exceptions;
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

        public FurnitureState Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            if (roomNameFrom == roomNameTo)
            {
                throw new InvalidFurnitureMovingException(roomNameFrom, roomNameTo);
            }
            var furnitureFrom = reader.Get(type, roomNameFrom, date);
            CheckRooms(roomNameFrom, roomNameTo, date);
            var furnitureCount = furnitureFrom.Count;
            RemoveFurnitureFromFirstRoom(furnitureFrom, date);
            var furnitureTo = reader.GetClosestLeftByDate(type, date, roomNameTo);
            var result = SetFurnitureToSecondRoom(furnitureFrom, furnitureTo, date, roomNameTo, furnitureCount);
            roomEventLogger.LogMoveFurniture(date, roomNameFrom, roomNameTo, furnitureCount, furnitureFrom);
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

        private FurnitureState RemoveFurnitureFromFirstRoom(FurnitureState furnitureStateFrom, DateTime date)
        {
            if (furnitureStateFrom.Date.Date < date.Date)
            {
                return creator.Create(furnitureStateFrom.Type, date, furnitureStateFrom.RoomId, 0);
            }
            furnitureStateFrom.Date = date.Date;
            furnitureStateFrom.Count = 0;
            return updater.Update(furnitureStateFrom);
        }

        private FurnitureState SetFurnitureToSecondRoom(
            FurnitureState furnitureStateFrom, FurnitureState furnitureStateTo, DateTime date, string roomTo, int furnitureFromCount)
        {
            if (furnitureStateTo == null)
            {
                var roomId = roomReader.Get(roomTo, date).Id;
                return creator.Create(furnitureStateFrom.Type, date, roomId, furnitureFromCount);
            }
            var count = furnitureStateTo.Count + furnitureFromCount;
            if (furnitureStateTo.Date.Date < date.Date)
            {
                return creator.Create(furnitureStateTo.Type, date, furnitureStateTo.RoomId, count);
            }
            furnitureStateTo.Count = count;
            return updater.Update(furnitureStateFrom);
        }
    }
}