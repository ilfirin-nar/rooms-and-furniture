using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business
{
    public interface IFurnitureSaver : IService
    {
        int Save(Furniture furniture);
    }
}