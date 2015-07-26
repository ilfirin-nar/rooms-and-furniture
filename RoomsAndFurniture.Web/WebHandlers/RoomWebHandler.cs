using System;
using RoomsAndFurniture.Web.Business;
using RoomsAndFurniture.Web.Business.Exceptions;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.Models.Results;
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

        public ClientData<RoomClientModel> Create(string name, DateTime date)
        {
            var room = mapper.Map(name, date);
            try
            {
                saver.Save(room);
            }
            catch (NotUniqueRoomNameException exception)
            {
                return new NonUniqueRoomNameResult(exception.RoomName);
            }
            return new SuccessResult<RoomClientModel>(room.MapTo<RoomClientModel>());
        }
    }
}