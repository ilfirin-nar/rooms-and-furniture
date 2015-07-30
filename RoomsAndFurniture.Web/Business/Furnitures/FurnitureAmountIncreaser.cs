using System;
using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureAmountIncreaser : IFurnitureAmountIncreaser
    {
        private readonly IFurnitureReader reader;
        private readonly IFurnitureCreator creator;
        private readonly IFurnitureUpdater updater;
        private readonly IRoomEventLogger roomEventLogger;
        private readonly IRepository<Furniture> furnitureRepository;
        private readonly IRepository<FurnitureLocation> furnitureLocationRepository;

        public FurnitureAmountIncreaser(
            IFurnitureReader reader,
            IFurnitureCreator creator,
            IFurnitureUpdater updater,
            IRoomEventLogger roomEventLogger,
            IRepository<Furniture> furnitureRepository,
            IRepository<FurnitureLocation> furnitureLocationRepository)
        {
            this.reader = reader;
            this.creator = creator;
            this.updater = updater;
            this.roomEventLogger = roomEventLogger;
            this.furnitureRepository = furnitureRepository;
            this.furnitureLocationRepository = furnitureLocationRepository;
        }

        public FurnitureState Increase(string type, DateTime date, string roomName, int increaseBy)
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