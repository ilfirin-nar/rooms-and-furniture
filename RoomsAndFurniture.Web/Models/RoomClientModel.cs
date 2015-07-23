using System;
using System.Collections.Generic;

namespace RoomsAndFurniture.Web.Models
{
    public class RoomClientModel
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Name { get; set; }

        public IList<FurnitureClientModel> Furniture { get; set; }
    }
}