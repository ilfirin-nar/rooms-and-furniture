using System;
using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureAmountIncreaser : IFurnitureAmountIncreaser
    {
        private readonly IFurnitureReader reader;
        private readonly IFurnitureCreator creator;
        private readonly IFurnitureUpdater updater;
        private readonly IRoomEventLogger roomEventLogger;

        public FurnitureAmountIncreaser(
            IFurnitureReader reader,
            IFurnitureCreator creator,
            IFurnitureUpdater updater,
            IRoomEventLogger roomEventLogger)
        {
            this.reader = reader;
            this.creator = creator;
            this.updater = updater;
            this.roomEventLogger = roomEventLogger;
        }

        public Furniture Increase(string type, DateTime date, string roomName, int increaseBy)
        {
            var furniture = reader.GetClosestLeftByDate(type, date, roomName);
            if (furniture == null)
            {
                return creator.Create(type, date, roomName, increaseBy);
            }
            if (furniture.Date.Date < date.Date)
            {
                return creator.Create(type, date, roomName, furniture.Count + increaseBy);
            }
            furniture.Count = furniture.Count + increaseBy;
            var result = updater.Update(furniture);
            roomEventLogger.LogAddFurniture(date, roomName, type, increaseBy);
            return result;
        }
    }
}