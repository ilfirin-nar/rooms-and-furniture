using System;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.Models.Results.Rooms;

namespace RoomsAndFurniture.Web.WebHandlers
{
    internal class RoomWebHandler : IRoomWebHandler
    {
        private readonly IRoomCreator creator;
        private readonly IRoomRemover roomRemover;

        public RoomWebHandler(IRoomCreator creator, IRoomRemover roomRemover)
        {
            this.creator = creator;
            this.roomRemover = roomRemover;
        }

        public ResultBase<RoomClientModel> Create(string name, DateTime date)
        {
            var room = new Room { Name = name, CreateDate = date };
            try
            {
                creator.Create(room);
            }
            catch (RoomAlreadyExistsException exception)
            {
                return new NonUniqueRoomNameResult(exception.RoomName, exception.Date);
            }
            return new SuccessResult<RoomClientModel>(room.MapTo<RoomClientModel>());
        }

        public ResultBase Remove(string name, string moveFurnitureToRoom, DateTime date)
        {
            var room = new Room { Name = name, RemoveDate = date };
            try
            {
                roomRemover.Remove(room, moveFurnitureToRoom);
            }
            catch (RoomNotFoundException exception)
            {
                return new NonUniqueRoomNameResult(exception.RoomName, exception.Date);
            }
            return new SuccessResult();
        }
    }
}