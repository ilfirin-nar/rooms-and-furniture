using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomCreator : IRoomCreator
    {
        private readonly IRoomChecker checker;
        private readonly IQueryBuilder queryBuilder;

        public RoomCreator(IRoomChecker checker, IQueryBuilder queryBuilder)
        {
            this.checker = checker;
            this.queryBuilder = queryBuilder;
        }

        public int Create(Room room)
        {
            if (checker.IsExists(room, room.CreateDate))
            {
                throw new RoomAlreadyExistsException(room.Name, room.CreateDate);
            }
            var criterion = new CreateRoomCriterion(room);
            return queryBuilder.Query<CreateRoomCriterion, int>().Proceed(criterion);
        }
    }
}