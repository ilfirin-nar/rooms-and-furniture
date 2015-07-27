using System;
using RoomsAndFurniture.Web.Enums;

namespace RoomsAndFurniture.Web.Domain
{
    public class RoomEvent
    {
        public RoomEvent(DateTime date, RoomEventType type, string description)
        {
            Date = date;
            Type = type;
            Description = description;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public RoomEventType Type { get; set; }

        public string Description { get; set; }
    }
}