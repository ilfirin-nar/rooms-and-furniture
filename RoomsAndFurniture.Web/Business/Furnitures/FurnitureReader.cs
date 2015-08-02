using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Business.Furnitures.Exceptions;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureReader : IFurnitureReader
    {
        private readonly IQueryBuilder queryBuilder;

        public FurnitureReader(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public Furniture Get(string type, int roomId, DateTime date)
        {
            var criterion = new GetFurnitureByTypeAndDateAndRoomIdCriterion(type, date, roomId);
            var furniture = queryBuilder.Query<GetFurnitureByTypeAndDateAndRoomIdCriterion, Furniture>().Proceed(criterion);
            if (furniture == null)
            {
                throw new FurnitureNotFoundException(type, roomId, date);
            }
            return furniture;
        }

        public IList<FurnitureState> Get(IList<int> roomsIds, DateTime date)
        {
            var critretion = new GetFurnitureItemsByRoomsIdsAndDateCriterion(roomsIds, date);
            return queryBuilder.Query<GetFurnitureItemsByRoomsIdsAndDateCriterion, IList<FurnitureState>>().Proceed(critretion);
        }
    }
}