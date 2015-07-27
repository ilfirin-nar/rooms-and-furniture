using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    public interface IRoomReader : IBusinessService
    {
        Room Get(string name, DateTime date);

        IDictionary<string, Room> GetRooms(params string[] roomNames);
    }
}