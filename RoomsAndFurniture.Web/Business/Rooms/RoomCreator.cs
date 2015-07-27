using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomCreator : IRoomCreator
    {
        private readonly IRoomChecker checker;
        private readonly IRoomEventLogger roomEventLogger;
        private readonly IQueryBuilder queryBuilder;

        public RoomCreator(
            IRoomChecker checker,
            IRoomEventLogger roomEventLogger,
            IQueryBuilder queryBuilder)
        {
            this.checker = checker;
            this.roomEventLogger = roomEventLogger;
            this.queryBuilder = queryBuilder;
        }

        public int Create(Room room)
        {
            if (checker.IsExists(room, room.CreateDate))
            {
                throw new RoomAlreadyExistsException(room.Name, room.CreateDate);
            }
            var criterion = new CreateRoomCriterion(room);
            var result = queryBuilder.Query<CreateRoomCriterion, int>().Proceed(criterion);
            roomEventLogger.LogCreateRoom(room);
            return result;
        }
    }
}