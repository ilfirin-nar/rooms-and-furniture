using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Domain
{
    public class Room : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? RemoveDate { get; set; }

        public string Name { get; set; }
    }
}