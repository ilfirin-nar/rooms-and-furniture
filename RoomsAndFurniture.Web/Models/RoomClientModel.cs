using System;
using System.Collections.Generic;

namespace RoomsAndFurniture.Web.Models
{
    public class RoomClientModel
    {
        public int RoomId { get; set; }

        public string Date { get; set; }

        public string RoomName { get; set; }

        public IList<FurnitureClientModel> FurnitureItems { get; set; }
    }
}