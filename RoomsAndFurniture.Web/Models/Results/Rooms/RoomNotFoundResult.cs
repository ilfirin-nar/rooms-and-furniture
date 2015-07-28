using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;

namespace RoomsAndFurniture.Web.Models.Results.Rooms
{

    public class RoomNotFoundResult : FailResult
    {
        private const string MessageTemplate = "Комната с именем {0} не существует на дату {1}";

        public RoomNotFoundResult(string roomName, DateTime date)
            : base(string.Format(MessageTemplate, roomName, date)) { }
    }

    public class RoomNotFoundResult<T> : FailResult<T>
    {
        private const string MessageTemplate = "Комната с именем {0} не существует на дату {1}";

        public RoomNotFoundResult(string roomName, DateTime date)
            : base(string.Format(MessageTemplate, roomName, date)) {}
    }
}