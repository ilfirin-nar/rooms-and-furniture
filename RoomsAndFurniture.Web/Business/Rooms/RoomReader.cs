using System;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomReader : IRoomReader
    {
        private readonly IQueryBuilder queryBuilder;

        public RoomReader(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public Room Get(string name, DateTime date)
        {
            var criterion = new GetRoomByNameAndDateCriterion(name, date);
            var room = queryBuilder.Query<GetRoomByNameAndDateCriterion, Room>().Proceed(criterion);
            if (room == null)
            {
                throw new RoomNotFoundException(name, date);
            }
            return room;
        }
    }
}