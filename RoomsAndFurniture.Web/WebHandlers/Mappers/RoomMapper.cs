using System;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.WebHandlers.Mappers
{
    internal class RoomMapper : IRoomMapper
    {
        public Room Map(string name, DateTime date)
        {
            return new Room
            {
                Name = name,
                CreateDate = date
            };
        }
    }
}