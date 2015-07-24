using System;

namespace RoomsAndFurniture.Web.Domain
{
    public class Furniture
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public int Count { get; set; }

        public int RoomId { get; set; }
    }
}