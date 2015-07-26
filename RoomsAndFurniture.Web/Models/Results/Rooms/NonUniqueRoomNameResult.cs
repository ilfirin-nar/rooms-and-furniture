using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;

namespace RoomsAndFurniture.Web.Models.Results.Rooms
{
    public class NonUniqueRoomNameResult : FailResult<RoomClientModel>
    {
        private const string MessageTemplate = "Комната с именем {0} уже существует на {1}";

        public NonUniqueRoomNameResult(string roomName, DateTime date)
            : base(string.Format(MessageTemplate, roomName, date)) { }
    }
}