using System;

namespace RoomsAndFurniture.Web.Business.Furnitures.Exceptions
{
    public class FurnitureNotFoundException : Exception
    {
        private const string MessageTemplate = "Furniture {0} not found in room with ID {1} at {2} exception";

        public string FurnitureType { get; private set; }

        public int RoomId { get; private set; }

        public DateTime Date { get; private set; }

        public FurnitureNotFoundException(string furnitureType, int roomId, DateTime date)
        {
            FurnitureType = furnitureType;
            RoomId = roomId;
            Date = date;
        }

        public override string Message
        {
            get { return string.Format(MessageTemplate, FurnitureType, RoomId, Date); }
        }
    }
}