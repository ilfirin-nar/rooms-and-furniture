using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureLocations
{
    public class GetFurnitureLocationByTypeRoomIdAndDateCriterion : ICriterion
    {
        public string Type { get; set; }

        public int RoomId { get; set; }

        public DateTime Date { get; set; }

        public GetFurnitureLocationByTypeRoomIdAndDateCriterion(string type, int roomId, DateTime date)
        {
            Type = type;
            RoomId = roomId;
            Date = date;
        }
    }
}