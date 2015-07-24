using System;
using System.Collections.Generic;

namespace RoomsAndFurniture.Web.Domain
{
    public class RoomState
    {
        public int RoomId { get; set; }

        public DateTime Date { get; set; }

        public IList<Furniture> FurnitureState { get; set; }
    }
}