using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.DataAccess
{
    public interface IFurnitureDao : IDao
    {
        int Save(Furniture furniture);
    }
}