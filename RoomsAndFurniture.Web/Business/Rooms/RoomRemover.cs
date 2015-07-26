using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomRemover : IRoomRemover
    {
        private readonly IRoomChecker checker;
        private readonly IQueryBuilder queryBuilder;

        public RoomRemover(IRoomChecker checker, IQueryBuilder queryBuilder)
        {
            this.checker = checker;
            this.queryBuilder = queryBuilder;
        }

        public int Remove(Room room, string moveFurnitureToRoom)
        {
            if (checker.IsExists(room, room.RemoveDate.Value))
            {
                throw new RoomNotFoundException(room.Name, room.RemoveDate.Value);
            }
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var criterion = new RemoveRoomCriterion(room);
            return queryBuilder.Query<RemoveRoomCriterion, int>().Proceed(criterion);            
        }
    }
}