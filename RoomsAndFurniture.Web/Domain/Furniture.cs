using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Domain
{
    public class Furniture : IEntity<int>
    {
        public Furniture() {}

        public Furniture(DateTime createDate, string type)
        {
            CreateDate = createDate;
            Type = type;
        }

        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? RemoveDate { get; set; }

        public string Type { get; set; }
    }
}