using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class GetRoomsByNamesCriterion : ICriterion
    {
        private readonly string[] names;

        public GetRoomsByNamesCriterion(string[] names)
        {
            this.names = names;
        }

        public string[] Names { get; set; }
    }
}