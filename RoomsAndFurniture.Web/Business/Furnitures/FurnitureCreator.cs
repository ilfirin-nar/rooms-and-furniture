using System;
using System.Collections.Generic;
using System.Linq;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Criterions.FurnitureCriterions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureCreator : IFurnitureCreator
    {
        private readonly IRoomReader roomReader;
        private readonly IQueryBuilder queryBuilder;

        public FurnitureCreator(
            IRoomReader roomReader,
            IQueryBuilder queryBuilder)
        {
            this.roomReader = roomReader;
            this.queryBuilder = queryBuilder;
        }

        public FurnitureState Create(string type, DateTime date, string roomName, int count)
        {
            var room = roomReader.Get(roomName, date);
            return Create(type, date, room.Id, count);
        }

        public FurnitureState Create(string type, DateTime date, int roomId, int count)
        {
//            var furniture = new Furniture
//            {
//                Type = type,
//                CreateDate = date
//            };
//            var critreion = new CreateFurnitureCriterion(furniture);
//            furniture.Id = queryBuilder.Query<CreateFurnitureCriterion, int>().Proceed(critreion);
//            return furniture;
            return null;
        }

        public void Create(IList<FurnitureState> furnitureItems)
        {
            if (!furnitureItems.Any())
            {
                return;
            }
            var critreion = new CreateFurnitureItemsCriterion(furnitureItems);
            queryBuilder.Command<CreateFurnitureItemsCriterion>().Proceed(critreion);
        }
    }
}