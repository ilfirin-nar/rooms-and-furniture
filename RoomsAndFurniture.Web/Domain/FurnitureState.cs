using System;

namespace RoomsAndFurniture.Web.Domain
{
    public class FurnitureState
    {
        public FurnitureState() {}

        public FurnitureState(FurnitureState furnitureState)
        {
            Id = furnitureState.Id;
            Date = furnitureState.Date;
            Type = furnitureState.Type;
            Count = furnitureState.Count;
            RoomId = furnitureState.RoomId;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public int Count { get; set; }

        public int RoomId { get; set; }
    }
}