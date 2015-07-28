using System.Collections.Generic;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.RoomCriterions
{
    public class GetRoomsByNamesCriterion : ICriterion
    {
        public string[] Names { get; set; }

        public GetRoomsByNamesCriterion(string[] names)
        {
            Names = names;
        }
    }
}