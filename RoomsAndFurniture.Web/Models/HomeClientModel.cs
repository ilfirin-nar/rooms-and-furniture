using System.Collections.Generic;

namespace RoomsAndFurniture.Web.Models
{
    public class HomeClientModel
    {
        public HomeClientModel(IList<RoomClientModel> rooms)
        {
            Rooms = rooms;
        }

        public IList<RoomClientModel> Rooms { get; set; }
    }
}