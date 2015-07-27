using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Room> Get(DateTime date)
        {
            var criterion = new GetRoomsByDateCriterion(date);
            return queryBuilder.Query<GetRoomsByDateCriterion, IList<Room>>().Proceed(criterion);
        }

        public IDictionary<string, Room> Get(params string[] roomNames)
        {
            var criterion = new GetRoomsByNamesCriterion(roomNames);
            var list = queryBuilder.Query<GetRoomsByNamesCriterion, IList<Room>>().Proceed(criterion);
            return roomNames.ToDictionary(rn => rn, rn => list.First(r => r.Name == rn));
        }
    }
}