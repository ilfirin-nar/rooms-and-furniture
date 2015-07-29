using System.Collections.Generic;

namespace RoomsAndFurniture.Web.Models
{
    public class HistoryClientModel
    {
        public HistoryClientModel(IList<RoomEventClientData> events, bool isShort)
        {
            Events = events;
            IsShort = isShort;
        }

        public bool IsShort { get; set; }

        public IList<RoomEventClientData> Events { get; set; }
    }
}