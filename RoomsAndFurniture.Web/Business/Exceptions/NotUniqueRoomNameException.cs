using System;

namespace RoomsAndFurniture.Web.Business.Exceptions
{
    public class NotUniqueRoomNameException : Exception
    {
        public string RoomName { get; private set; }

        public NotUniqueRoomNameException(string name)
        {
            RoomName = name;
        }

        public override string Message
        {
            get { return string.Format("Room with name {0} already exist", RoomName); }
        }
    }
}