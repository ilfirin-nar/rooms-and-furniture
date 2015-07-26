using System;

namespace RoomsAndFurniture.Web.Business.Rooms.Exceptions
{
    public class RoomAlreadyExistsException : Exception
    {
        public string RoomName { get; private set; }

        public DateTime Date { get; private set; }

        public RoomAlreadyExistsException(string name, DateTime date)
        {
            Date = date;
            RoomName = name;
        }

        public override string Message
        {
            get { return string.Format("Room with name {0} already exist at date {1}", RoomName, Date); }
        }
    }
}