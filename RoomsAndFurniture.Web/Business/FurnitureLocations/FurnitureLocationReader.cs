using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Business.Furnitures.Exceptions;
using RoomsAndFurniture.Web.Criterions.FurnitureLocations;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.FurnitureLocations
{
    internal class FurnitureLocationReader : IFurnitureLocationReader
    {
        private readonly IQueryBuilder queryBuilder;

        public FurnitureLocationReader(IQueryBuilder queryBuilder)
        {
            this.queryBuilder = queryBuilder;
        }

        public IList<FurnitureLocation> Get(string type, int roomId, DateTime date)
        {
            var criterion = new GetFurnitureLocationByTypeRoomIdAndDateCriterion(type, roomId, date);
            var locations = queryBuilder.Query<GetFurnitureLocationByTypeRoomIdAndDateCriterion, IList<FurnitureLocation>>().Proceed(criterion);
            if (locations == null || locations.Count == 0)
            {
                throw new FurnitureNotFoundException(type, roomId, date);
            }
            return locations;
        }

        public IList<FurnitureLocation> Get(int roomId, DateTime date)
        {
            var criterion = new GetFurnitureLocationByRoomIdAndDateCriterion(roomId, date);
            return queryBuilder.Query<GetFurnitureLocationByRoomIdAndDateCriterion, IList<FurnitureLocation>>().Proceed(criterion);
        }
    }
}