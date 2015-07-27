using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.RoomEvents
{
    public interface IRoomEventsReader : IBusinessService
    {
        IList<RoomEvent> Get(bool isShort);
    }
}