using RoomsAndFurniture.Web.Infrastructure.ClientModels;

namespace RoomsAndFurniture.Web.Models.Results
{
    public class NonUniqueRoomNameResult : FailResult<RoomClientModel>
    {
        private const string MessageTemplate = "Комната с именем {0} уже существует";

        public NonUniqueRoomNameResult(string roomName) : base(string.Format(MessageTemplate, roomName)) {}
    }
}