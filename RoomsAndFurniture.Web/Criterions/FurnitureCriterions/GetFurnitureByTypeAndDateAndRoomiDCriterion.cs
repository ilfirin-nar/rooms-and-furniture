using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class GetFurnitureByTypeAndDateAndRoomIdCriterion : ICriterion
    {
        public GetFurnitureByTypeAndDateAndRoomIdCriterion(string type, DateTime date, int roomId)
        {
            Type = type;
            Date = date;
            RoomId = roomId;
        }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public int RoomId { get; set; }
    }
}