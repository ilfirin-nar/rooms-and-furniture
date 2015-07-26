using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business
{
    public interface IRoomSaver : IBusinessService
    {
        void Save(Room room);
    }
}