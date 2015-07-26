using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class SaveRoomCriterion : ICriterion
    {
        public SaveRoomCriterion(Room room)
        {
            Room = room;
        }

        public Room Room { get; private set; } 
    }
}