using System;

namespace RoomsAndFurniture.Web.Domain
{
    public class Room
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? RemoveDate { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}