using System;
using RoomsAndFurniture.Web.Business.Furnitures;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.Attributes;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    internal class RoomRemover : IRoomRemover
    {
        private readonly IRoomReader reader;
        private readonly IRoomChecker checker;
        private readonly IFurnitureMover furnitureMover;
        private readonly IRepository<Room> repository;

        public RoomRemover(
            IRoomReader reader,
            IRoomChecker checker,
            IFurnitureMover furnitureMover,
            IRepository<Room> repository)
        {
            this.reader = reader;
            this.checker = checker;
            this.furnitureMover = furnitureMover;
            this.repository = repository;
        }

        [Transactional]
        public void Remove(string name, string roomTo, DateTime date)
        {
            furnitureMover.Move(name, roomTo, date);
            Remove(name, date);
        }

        public void RemoveWithoutMoving(string name, DateTime date)
        {
            if (!checker.IsExistAndEmpty(name, date))
            {
                throw new RoomNotFoundOrNotEmptyException(name, date);
            }
            Remove(name, date);
        }

        private void Remove(string name, DateTime date)
        {
            var room = reader.Get(name, date);
            room.RemoveDate = date;
            repository.Save(room);
        }
    }
}