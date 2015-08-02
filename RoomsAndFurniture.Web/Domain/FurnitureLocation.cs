using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Domain
{
    public class FurnitureLocation : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int FurnitureId { get; set; }

        public int RoomId { get; set; }
    }
}