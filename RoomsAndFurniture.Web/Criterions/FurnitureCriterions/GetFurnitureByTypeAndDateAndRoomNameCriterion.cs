using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class GetFurnitureByTypeAndDateAndRoomNameCriterion : ICriterion
    {
        public GetFurnitureByTypeAndDateAndRoomNameCriterion(string type, DateTime date, string roomName)
        {
            Type = type;
            Date = date;
            RoomName = roomName;
        }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string RoomName { get; set; }
    }
}