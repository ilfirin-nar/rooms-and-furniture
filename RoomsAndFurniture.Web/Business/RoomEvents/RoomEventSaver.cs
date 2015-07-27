using RoomsAndFurniture.Web.Criterions.RoomEventsCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.RoomEvents
{
    internal class RoomEventSaver : IRoomEventSaver
    {
        private readonly IQueryBuilder queryBuilder;

        public RoomEventSaver(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public void Save(RoomEvent roomEvent)
        {
            var criterion = new SaveRoomEventCriterion(roomEvent);
            queryBuilder.Command<SaveRoomEventCriterion>().Proceed(criterion);
        }
    }
}