using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class CreateRoomCriterion : ICriterion
    {
        public CreateRoomCriterion(Room room)
        {
            Room = room;
        }

        public Room Room { get; private set; } 
    }
}