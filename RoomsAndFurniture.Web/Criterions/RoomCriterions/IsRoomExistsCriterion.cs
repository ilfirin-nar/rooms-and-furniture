using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class IsRoomExistsCriterion : ICriterion
    {
        public IsRoomExistsCriterion(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; private set; }

        public DateTime Date { get; private set; }
    }
}