using System;
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

        public FurnitureCreator(IRoomReader roomReader, IQueryBuilder queryBuilder)
        {
            this.roomReader = roomReader;
            this.queryBuilder = queryBuilder;
        }

        public int Create(string type, DateTime date, string roomName, int count)
        {
            var room = roomReader.Get(roomName, date);
            var furniture = new Furniture
            {
                Type = type,
                Date = date,
                RoomId = room.Id,
                Count = count
            };
            var critreion = new CreateFurnitureCriterion(furniture);
            return queryBuilder.Query<CreateFurnitureCriterion, int>().Proceed(critreion);
        }
    }
}