using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureLocations
{
    public class GetFurnitureLocationByRoomIdAndDateCriterion : ICriterion
    {
        public int RoomId { get; set; }

        public DateTime Date { get; set; }

        public GetFurnitureLocationByRoomIdAndDateCriterion(int roomId, DateTime date)
        {
            RoomId = roomId;
            Date = date;
        }
    }
}