using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Infrastructure.Database;

namespace RoomsAndFurniture.Web.Domain
{
    public class FurnitureLocation : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int FurnitureId { get; set; }

        public int RoomId { get; set; }
    }
}