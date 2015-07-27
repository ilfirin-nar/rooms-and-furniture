using System.Collections.Generic;
using RoomsAndFurniture.Web.Criterions.RoomEventsCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.RoomEvents
{
    internal class RoomEventsReader : IRoomEventsReader
    {
        private readonly IQueryBuilder queryBuilder;

        public RoomEventsReader(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public IList<RoomEvent> Get(bool isShort)
        {
            var criterion = new GetRoomEventsCriterion(isShort);
            return queryBuilder.Query<GetRoomEventsCriterion, IList<RoomEvent>>().Proceed(criterion);
        }
    }
}