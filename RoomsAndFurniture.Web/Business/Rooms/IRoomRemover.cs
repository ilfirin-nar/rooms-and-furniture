using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    public interface IRoomRemover : IBusinessService
    {
        int Remove(Room room, string moveFurnitureToRoom);
    }
}