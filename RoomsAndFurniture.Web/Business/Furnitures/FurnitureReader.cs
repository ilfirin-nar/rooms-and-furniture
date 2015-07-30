using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Возвращает состояние мебели на ближайшую слева (более ранюю) дату или, если запись есть, на заданную.
        /// </summary>
        public FurnitureState GetClosestLeftByDate(string type, DateTime date, string roomName)
        {
            var criterion = new GetFurnitureByTypeAndDateAndRoomNameCriterion(type, date, roomName);
            return queryBuilder.Query<GetFurnitureByTypeAndDateAndRoomNameCriterion, FurnitureState>().Proceed(criterion);
        }

        public FurnitureState Get(string type, string roomName, DateTime date)
        {
            var furnitureFrom = GetClosestLeftByDate(type, date, roomName);
            if (furnitureFrom == null)
            {
                throw new FurnitureNotFoundException(type, roomName, date);
            }
            return furnitureFrom;
        }

        public IList<FurnitureState> Get(IList<int> roomsIds, DateTime date)
        {
            var critretion = new GetFurnitureItemsByRoomsIdsAndDateCriterion(roomsIds, date);
            return queryBuilder.Query<GetFurnitureItemsByRoomsIdsAndDateCriterion, IList<FurnitureState>>().Proceed(critretion);
        }

        public IList<FurnitureState> GetFurnitureItems(Room room, DateTime date)
        {
            var critretion = new GetFurnitureItemsByRoomIdAndDateCriterion(room.Id, date);
            return queryBuilder.Query<GetFurnitureItemsByRoomIdAndDateCriterion, IList<FurnitureState>>().Proceed(critretion);
        }

        public IList<FurnitureState> GetFurnitureItems(IList<string> furnitureTypes, Room room, DateTime date)
        {
            var critretion = new GetFurnitureItemsByRoomIdAndDateAndTypesCriterion(room.Id, date, furnitureTypes.ToArray());
            return queryBuilder.Query<GetFurnitureItemsByRoomIdAndDateAndTypesCriterion, IList<FurnitureState>>().Proceed(critretion);
        }
    }
}