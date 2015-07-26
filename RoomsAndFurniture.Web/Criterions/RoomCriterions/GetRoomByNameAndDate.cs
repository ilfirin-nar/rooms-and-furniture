using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class GetRoomByNameAndDateCriterion : ICriterion
    {
        public GetRoomByNameAndDateCriterion(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}