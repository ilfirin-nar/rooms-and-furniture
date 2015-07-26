using System;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomChecker : IRoomChecker
    {
        private readonly IQueryBuilder queryBuilder;

        public RoomChecker(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public bool IsExists(Room room, DateTime date)
        {
            var criterion = new IsRoomExistsCriterion(room.Name, date);
            return queryBuilder.Query<IsRoomExistsCriterion, bool>().Proceed(criterion);
        }
    }
}