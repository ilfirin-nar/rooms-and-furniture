using RoomsAndFurniture.Web.DataAccess;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.Business
{
    internal class FurnitureSaver : IFurnitureSaver
    {
        private readonly IFurnitureDao dao;

        public FurnitureSaver(IFurnitureDao dao)
        {
            this.dao = dao;
        }

        public int Save(Furniture furniture)
        {
            return dao.Save(furniture);
        }
    }
}