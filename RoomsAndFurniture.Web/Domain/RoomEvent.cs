using System;
using RoomsAndFurniture.Web.Enums;

namespace RoomsAndFurniture.Web.Domain
{
    public class RoomEvent
    {
        public RoomEvent(DateTime date, RoomEventType type, string descripton)
        {
            Date = date;
            Type = type;
            Descripton = descripton;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public RoomEventType Type { get; set; }

        public string Descripton { get; set; }
    }
}