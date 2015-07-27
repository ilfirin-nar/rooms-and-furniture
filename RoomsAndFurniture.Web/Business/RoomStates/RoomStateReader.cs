using System;
using System.Collections.Generic;
using System.Linq;
using RoomsAndFurniture.Web.Business.Furnitures;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.Business.RoomStates
{
    internal class RoomStateReader : IRoomStateReader
    {
        private readonly IRoomReader roomReader;
        private readonly IFurnitureReader furnitureReader;

        public RoomStateReader(
            IRoomReader roomReader,
            IFurnitureReader furnitureReader)
        {
            this.roomReader = roomReader;
            this.furnitureReader = furnitureReader;
        }

        public IList<RoomState> Get(DateTime date)
        {
            var rooms = roomReader.Get(date);
            return rooms.Any() ? GetRoomsStates(rooms, date) : new List<RoomState>();
        }

        private IList<RoomState> GetRoomsStates(IList<Room> rooms, DateTime date)
        {
            var roomsIds = rooms.Select(r => r.Id).ToList();
            var furnitureItems = furnitureReader.Get(roomsIds, date);
            return rooms.Select(room => new RoomState
            {
                RoomId = room.Id,
                Date = date,
                RoomName = room.Name,
                FurnitureItems = furnitureItems.Where(f => f.RoomId == room.Id).ToList()
            }).ToList();
        }
    }
}