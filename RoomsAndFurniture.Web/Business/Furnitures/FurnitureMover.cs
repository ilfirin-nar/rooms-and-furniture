using System;
using System.Collections.Generic;
using System.Linq;
using RoomsAndFurniture.Web.Business.FurnitureLocations;
using RoomsAndFurniture.Web.Business.Furnitures.Exceptions;
using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.Attributes;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureMover : IFurnitureMover 
    {
        private readonly IRepository<Furniture> repository;
        private readonly IFurnitureLocationReader locationReader;
        private readonly IRoomReader roomReader;
        private readonly IRepository<FurnitureLocation> locationRepository;
        private readonly IRoomEventLogger eventLogger;

        public FurnitureMover(
            IRepository<Furniture> repository,
            IFurnitureLocationReader locationReader,
            IRoomReader roomReader,
            IRepository<FurnitureLocation> locationRepository,
            IRoomEventLogger eventLogger)
        {
            this.repository = repository;
            this.locationReader = locationReader;
            this.roomReader = roomReader;
            this.locationRepository = locationRepository;
            this.eventLogger = eventLogger;
        }

        [Transactional]
        public void Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            Move(roomFromId => locationReader.Get(type, roomFromId, date), roomNameFrom, roomNameTo, date);
        }

        [Transactional]
        public void Move(string roomNameFrom, string roomNameTo, DateTime date)
        {
            Move(roomFromId => locationReader.Get(roomFromId, date), roomNameFrom, roomNameTo, date);
        }

        private void Move(Func<int, IList<FurnitureLocation>> oldLocationsFunc, string roomNameFrom, string roomNameTo, DateTime date)
        {
            CheckRooms(roomNameFrom, roomNameTo);
            var roomFrom = roomReader.Get(roomNameFrom, date);
            var roomTo = roomReader.Get(roomNameTo, date);
            var oldLocations = oldLocationsFunc(roomFrom.Id);
            var newLocations = new List<FurnitureLocation>();
            foreach (var oldLocation in oldLocations)
            {
                oldLocation.EndDate = date;
                newLocations.Add(new FurnitureLocation
                {
                    BeginDate = date,
                    RoomId = roomTo.Id,
                    FurnitureId = oldLocation.FurnitureId
                });
            }
            locationRepository.Save(oldLocations);
            locationRepository.Save(newLocations);
            var furniture = repository.Get(oldLocations.First().FurnitureId);
            eventLogger.LogMoveFurniture(date, roomNameFrom, roomNameTo, oldLocations.Count, furniture.Type);
        }

        private static void CheckRooms(string roomNameFrom, string roomNameTo)
        {
            if (roomNameFrom == roomNameTo)
            {
                throw new InvalidFurnitureMovingException(roomNameFrom, roomNameTo);
            }            
        }
    }
}