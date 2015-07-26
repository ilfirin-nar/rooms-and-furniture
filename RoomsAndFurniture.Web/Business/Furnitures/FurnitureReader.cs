using System;
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

        /// <summary>
        /// Возвращает состояние мебели на ближайшую слева (более ранюю) дату или, если запись есть, на заданную.
        /// </summary>
        public Furniture GetClosestLeftByDate(string type, DateTime date, string roomName)
        {
            var criterion = new GetFurnitureByTypeAndDateAndRoomNameCriterion(type, date, roomName);
            return queryBuilder.Query<GetFurnitureByTypeAndDateAndRoomNameCriterion, Furniture>().Proceed(criterion);
        }
    }
}