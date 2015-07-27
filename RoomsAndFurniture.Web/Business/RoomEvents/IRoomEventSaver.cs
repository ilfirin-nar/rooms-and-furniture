using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.RoomEvents
{
    public interface IRoomEventSaver : IBusinessService
    {
        void Save(RoomEvent roomEvent);
    }
}