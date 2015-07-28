using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;

namespace RoomsAndFurniture.Web.Models.Results.Rooms
{
    public class RoomNotExistOrNotEmptyResult : FailResult<RoomClientModel>
    {
        private const string MessageTemplate = "Комната с именем {0} не существует или не пуста на {1}";

        public RoomNotExistOrNotEmptyResult(string roomName, DateTime date)
            : base(string.Format(MessageTemplate, roomName, date.ToString("dd'.'MM'.'yyyy"))) { }
    }
}