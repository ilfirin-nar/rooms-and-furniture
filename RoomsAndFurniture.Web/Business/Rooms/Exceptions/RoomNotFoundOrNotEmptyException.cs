using System;

namespace RoomsAndFurniture.Web.Business.Rooms.Exceptions
{
    public class RoomNotFoundOrNotEmptyException : Exception
    {
        public string RoomName { get; private set; }

        public DateTime Date { get; private set; }

        public RoomNotFoundOrNotEmptyException(string name, DateTime date)
        {
            Date = date;
            RoomName = name;
        }

        public override string Message
        {
            get { return string.Format("Room with name {0} not found or not empty at date {1}", RoomName, Date); }
        }
    }
}