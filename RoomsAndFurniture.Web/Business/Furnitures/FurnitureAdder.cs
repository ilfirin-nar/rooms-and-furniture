using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.Attributes;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureAdder : IFurnitureAdder
    {
        private readonly IRepository<Furniture> repository;
        private readonly IRepository<FurnitureLocation> locationRepository;
        private readonly IRoomReader roomReader;
        private readonly IRoomEventLogger eventLogger;

        public FurnitureAdder(
            IRepository<Furniture> repository,
            IRepository<FurnitureLocation> locationRepository,
            IRoomReader roomReader,
            IRoomEventLogger eventLogger)
        {
            this.repository = repository;
            this.locationRepository = locationRepository;
            this.roomReader = roomReader;
            this.eventLogger = eventLogger;
        }

        [Transactional]
        public int Add(Furniture furniture, string roomName)
        {
            var id = repository.Save(furniture);
            var room = roomReader.Get(roomName, furniture.CreateDate);
            var location = new FurnitureLocation
            {
                BeginDate = furniture.CreateDate,
                FurnitureId = id,
                RoomId = room.Id
            };
            locationRepository.Save(location);
            eventLogger.LogAddFurniture(furniture.CreateDate, roomName, furniture.Type, 1);
            return id;
        }
    }
} 