using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class GetFurnitureItemsByRoomIdAndDateCriterion : ICriterion
    {
        public int RoomId { get; set; }

        public DateTime Date { get; set; }

        public GetFurnitureItemsByRoomIdAndDateCriterion(int roomId, DateTime date)
        {
            RoomId = roomId;
            Date = date;
        }
    }
}