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

        public FurnitureAdder(
            IRepository<Furniture> repository,
            IRepository<FurnitureLocation> locationRepository,
            IRoomReader roomReader)
        {
            this.repository = repository;
            this.locationRepository = locationRepository;
            this.roomReader = roomReader;
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
            return id;
        }
    }
} 