using RoomsAndFurniture.Web.Enums;

namespace RoomsAndFurniture.Web.Domain
{
    public class Furniture
    {
        public int Id { get; set; }

        public FurnitureType Type { get; set; }

        public int Count { get; set; }

        public int RoomId { get; set; }
    }
}