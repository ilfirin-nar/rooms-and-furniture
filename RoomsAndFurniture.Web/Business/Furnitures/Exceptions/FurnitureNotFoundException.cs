using System;

namespace RoomsAndFurniture.Web.Business.Furnitures.Exceptions
{
    public class FurnitureNotFoundException : Exception
    {
        private const string MessageTemplate = "Furniture not found exception";

        public string FurnitureType { get; private set; }

        public string RoomName { get; private set; }

        public DateTime Date { get; private set; }

        public FurnitureNotFoundException(string furnitureType, string roomName, DateTime date)
        {
            FurnitureType = furnitureType;
            RoomName = roomName;
            Date = date;
        }

        public override string Message
        {
            get { return string.Format(MessageTemplate, FurnitureType, RoomName, Date); }
        }
    }
}