using RoomsAndFurniture.Web.Business.Exceptions;
using RoomsAndFurniture.Web.DataAccess;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.Business
{
    internal class RoomChecker : IRoomChecker
    {
        private readonly IRoomDao dao;

        public RoomChecker(IRoomDao dao)
        {
            this.dao = dao;
        }

        public void Check(Room room)
        {
            if (dao.IsExists(room.Name))
            {
                throw new NotUniqueRoomNameException(room.Name);
            }
        }
    }
}