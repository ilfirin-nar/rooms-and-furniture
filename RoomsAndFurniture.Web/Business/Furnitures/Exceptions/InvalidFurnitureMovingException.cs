using System;

namespace RoomsAndFurniture.Web.Business.Furnitures.Exceptions
{
    public class InvalidFurnitureMovingException : Exception
    {
        public string RoomFrom { get; set; }

        public string RoomTo { get; set; }

        public InvalidFurnitureMovingException(string roomFrom, string roomTo)
        {
            RoomFrom = roomFrom;
            RoomTo = roomTo;
        }
    }
}