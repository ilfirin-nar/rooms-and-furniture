using System;

namespace RoomsAndFurniture.Web.Domain
{
    public class Furniture
    {
        public Furniture() {}

        public Furniture(Furniture furniture)
        {
            Id = furniture.Id;
            Date = furniture.Date;
            Type = furniture.Type;
            Count = furniture.Count;
            RoomId = furniture.RoomId;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public int Count { get; set; }

        public int RoomId { get; set; }
    }
}