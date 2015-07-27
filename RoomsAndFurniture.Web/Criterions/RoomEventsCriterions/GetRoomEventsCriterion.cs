using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomEventsCriterions
{
    public class GetRoomEventsCriterion : ICriterion
    {
        public bool IsShort { get; set; }

        public GetRoomEventsCriterion(bool isShort)
        {
            IsShort = isShort;
        }
    }
}