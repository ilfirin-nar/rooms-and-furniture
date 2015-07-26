using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Infrastructure.Database
{
    public interface IDatabaseCreator : IService
    {
        void Create(string databaseFileName);
    }
}