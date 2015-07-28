using System;
using RoomsAndFurniture.Web.Business.Furnitures;
using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomRemover : IRoomRemover
    {
        private readonly IRoomReader reader;
        private readonly IRoomChecker checker;
        private readonly IFurnitureMultiMover furnitureMultiMover;
        private readonly IRoomEventLogger roomEventLogger;
        private readonly IQueryBuilder queryBuilder;

        public RoomRemover(
            IRoomReader reader,
            IRoomChecker checker,
            IFurnitureMultiMover furnitureMultiMover,
            IRoomEventLogger roomEventLogger,
            IQueryBuilder queryBuilder)
        {
            this.reader = reader;
            this.checker = checker;
            this.furnitureMultiMover = furnitureMultiMover;
            this.roomEventLogger = roomEventLogger;
            this.queryBuilder = queryBuilder;
        }

        public void Remove(string name, string roomTo, DateTime date)
        {
            CheckRooms(name, roomTo, date);
            var rooms = reader.Get(name, roomTo);
            furnitureMultiMover.MoveAll(rooms[name], rooms[roomTo], date);
            var criterion = new RemoveRoomCriterion(new Room { Name = name, RemoveDate = date });
            queryBuilder.Query<RemoveRoomCriterion, bool>().Proceed(criterion);
            roomEventLogger.LogRemoveRoom(date, name);
        }

        private void CheckRooms(string roomNameFrom, string roomNameTo, DateTime date)
        {
            if (!checker.IsExists(roomNameFrom, date))
            {
                throw new RoomNotFoundException(roomNameFrom, date);
            }
            if (!checker.IsExists(roomNameTo, date))
            {
                throw new RoomNotFoundException(roomNameTo, date);
            }
        }
    }
}