using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomCreator : IRoomCreator
    {
        private readonly IRoomChecker checker;
        private readonly IRoomEventLogger eventLogger;
        private readonly IRepository<Room> repository;

        public RoomCreator(
            IRoomChecker checker,
            IRoomEventLogger eventLogger,
            IRepository<Room> repository)
        {
            this.checker = checker;
            this.eventLogger = eventLogger;
            this.repository = repository;
        }

        public int Create(Room room)
        {
            if (checker.IsExists(room, room.CreateDate))
            {
                throw new RoomAlreadyExistsException(room.Name, room.CreateDate);
            }
            repository.Save(room);
            eventLogger.LogCreateRoom(room);
            return room.Id;
        }
    }
}