using RoomsAndFurniture.Web.DataAccess;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.Business
{
    internal class RoomSaver : IRoomSaver
    {
        private readonly IRoomChecker roomChecker;
        private readonly IRoomDao dao;

        public RoomSaver(IRoomChecker roomChecker, IRoomDao dao)
        {
            this.roomChecker = roomChecker;
            this.dao = dao;
        }

        public void Save(Room room)
        {
            roomChecker.Check(room);
            dao.Create(room);
        }
    }
}