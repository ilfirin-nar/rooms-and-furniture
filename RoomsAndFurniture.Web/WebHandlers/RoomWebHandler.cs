using System;
using RoomsAndFurniture.Web.Business;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.WebHandlers.Mappers;

namespace RoomsAndFurniture.Web.WebHandlers
{
    internal class RoomWebHandler : IRoomWebHandler
    {
        private readonly IRoomMapper mapper;
        private readonly IRoomSaver saver;

        public RoomWebHandler(
            IRoomMapper mapper,
            IRoomSaver saver)
        {
            this.mapper = mapper;
            this.saver = saver;
        }

        public RoomClientModel Create(string name, DateTime date)
        {
            var room = mapper.Map(name, date);
            saver.Save(room);
            return room.MapTo<RoomClientModel>();
        }
    }
}