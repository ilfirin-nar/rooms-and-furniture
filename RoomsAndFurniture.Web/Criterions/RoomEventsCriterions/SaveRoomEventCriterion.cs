using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomEventsCriterions
{
    public class SaveRoomEventCriterion : ICriterion
    {
        public RoomEvent RoomEvent { get; set; }

        public SaveRoomEventCriterion(RoomEvent roomEvent)
        {
            RoomEvent = roomEvent;
        }
    }
}