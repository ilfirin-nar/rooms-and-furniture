using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.DataAccess
{
    public interface IRoomDao : IDao
    {
        int Create(Room room);

        bool IsExists(string name);
    }
}