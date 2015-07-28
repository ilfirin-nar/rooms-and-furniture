using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Business.RoomStates;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.Models.Results.Rooms;
using RoomsAndFurniture.Web.WebHandlers.Mappers;

namespace RoomsAndFurniture.Web.WebHandlers
{
    internal class RoomWebHandler : IRoomWebHandler
    {
        private readonly IRoomStateReader roomStateReader;
        private readonly IRoomCreator creator;
        private readonly IRoomRemover roomRemover;
        private readonly IRoomMapper mapper;

        public RoomWebHandler(
            IRoomStateReader roomStateReader,
            IRoomCreator creator,
            IRoomRemover roomRemover,
            IRoomMapper mapper)
        {
            this.roomStateReader = roomStateReader;
            this.creator = creator;
            this.roomRemover = roomRemover;
            this.mapper = mapper;
        }

        public ResultBase<IList<RoomClientModel>> Get(DateTime? date = null)
        {
            if (!date.HasValue)
            {
                date = DateTime.Today;
            }
            var roomsStates = roomStateReader.Get(date.Value);
            var result = mapper.Map(roomsStates);
            return new SuccessResult<IList<RoomClientModel>>(result);
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
            return new SuccessResult<RoomClientModel>(mapper.Map(room));
        }

        public ResultBase Remove(string name, string roomTo, DateTime date)
        {
            try
            {
                roomRemover.Remove(name, roomTo, date);
            }
            catch (RoomNotFoundException exception)
            {
                return new NonUniqueRoomNameResult(exception.RoomName, exception.Date);
            }
            return new SuccessResult();
        }
    }
}