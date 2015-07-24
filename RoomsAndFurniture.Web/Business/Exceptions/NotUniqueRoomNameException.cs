using System;

namespace RoomsAndFurniture.Web.Business.Exceptions
{
    public class NotUniqueRoomNameException : Exception
    {
        private readonly string name;

        public NotUniqueRoomNameException(string name)
        {
            this.name = name;
        }

        public override string Message
        {
            get { return string.Format("Room with name {0} already exist", name); }
        }
    }
}