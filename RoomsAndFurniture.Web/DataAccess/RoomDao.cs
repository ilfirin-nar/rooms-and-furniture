using RoomsAndFurniture.Web.Criterions.RoomCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.DataAccess
{
    internal class RoomDao : IRoomDao
    {
        private readonly IQueryBuilder queryBuilder;

        public RoomDao(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public int Create(Room room)
        {
            var criterion = new SaveRoomCriterion(room);
            return queryBuilder.Query<SaveRoomCriterion, int>().Proceed(criterion);
        }

        public bool IsExists(string name)
        {
            var criterion = new IsExistsCriterion(name);
            return queryBuilder.Query<IsExistsCriterion, bool>().Proceed(criterion);
        }
    }
}