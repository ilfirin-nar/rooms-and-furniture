namespace RoomsAndFurniture.Web.Models
{
    public class FurnitureClientModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int Count { get; set; }

        public int RoomId { get; set; }
    }
}