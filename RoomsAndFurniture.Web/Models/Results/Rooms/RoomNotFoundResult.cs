using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;

namespace RoomsAndFurniture.Web.Models.Results.Rooms
{
    public class RoomNotFoundResult : FailResult<RoomClientModel>
    {
        private const string MessageTemplate = "Комната с именем {0} не существует на дату {1}";

        public RoomNotFoundResult(string roomName, DateTime date)
            : base(string.Format(MessageTemplate, roomName, date)) { }
    }
}