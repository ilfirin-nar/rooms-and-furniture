using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class GetFurnitureItemsByRoomIdAndDateAndTypesCriterion : ICriterion
    {
        public int RoomId { get; set; }

        public DateTime Date { get; set; }

        public string[] FurnitureTypes { get; set; }

        public GetFurnitureItemsByRoomIdAndDateAndTypesCriterion(int roomId, DateTime date, string[] furnitureTypes)
        {
            RoomId = roomId;
            Date = date;
            FurnitureTypes = furnitureTypes;
        }
    }
}