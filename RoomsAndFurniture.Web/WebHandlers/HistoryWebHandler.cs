using System.Collections.Generic;
using System.Linq;
using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    internal class HistoryWebHandler : IHistoryWebHandler
    {
        private readonly IRoomEventsReader roomEventsReader;

        public HistoryWebHandler(IRoomEventsReader roomEventsReader)
        {
            this.roomEventsReader = roomEventsReader;
        }

        public ResultBase<IList<RoomEventClientData>> Get(bool isShort)
        {
            var roomEvents = roomEventsReader.Get(isShort);
            var result = roomEvents.Select(e => e.MapTo<RoomEventClientData>()).ToList();
            return new SuccessResult<IList<RoomEventClientData>>(result);
        }
    }
}