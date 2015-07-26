using System;

namespace RoomsAndFurniture.Web.Business.Furnitures.Exceptions
{
    public class FurnitureNotFoundException : Exception
    {
        public FurnitureNotFoundException() : base("Furniture not found exception") {}
    }
}