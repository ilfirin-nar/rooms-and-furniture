using System;

namespace RoomsAndFurniture.Web.Business.Rooms.Exceptions
{
    public class RoomNotFoundException : Exception
    {
        public string RoomName { get; private set; }

        public DateTime Date { get; private set; }

        public RoomNotFoundException(string name, DateTime date)
        {
            Date = date;
            RoomName = name;
        }

        public override string Message
        {
            get { return string.Format("Room with name {0} not found at date {1}", RoomName, Date); }
        }
    }
}