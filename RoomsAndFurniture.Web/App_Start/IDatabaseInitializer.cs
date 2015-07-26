using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web
{
    public interface IDatabaseInitializer : IService
    {
        void Initialize();
    }
}