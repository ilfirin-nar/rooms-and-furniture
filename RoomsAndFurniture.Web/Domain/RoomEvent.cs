using System;
using RoomsAndFurniture.Web.Enums;

namespace RoomsAndFurniture.Web.Domain
{
    public class RoomEvent
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public RoomEventType Type { get; set; }

        public Room Room { get; set; }

        public Furniture Furniture { get; set; }
    }
}