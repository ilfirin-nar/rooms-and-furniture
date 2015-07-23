using System.Collections.Generic;

namespace RoomsAndFurniture.Web.Models
{
    public class HistoryClientModel
    {
        public bool IsShort { get; set; }

        public IList<RoomEventClientData> Events { get; set; }
    }
}