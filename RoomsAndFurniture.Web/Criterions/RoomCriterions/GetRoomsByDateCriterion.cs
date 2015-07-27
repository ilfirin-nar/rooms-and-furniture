using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class GetRoomsByDateCriterion : ICriterion
    {
        public DateTime Date { get; set; }

        public GetRoomsByDateCriterion(DateTime date)
        {
            Date = date;
        }
    }
}