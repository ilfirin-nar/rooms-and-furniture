using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class RemoveRoomCriterion : ICriterion
    {
        public RemoveRoomCriterion(Room room)
        {
            Room = room;
        }

        public Room Room { get; private set; } 
    }
}