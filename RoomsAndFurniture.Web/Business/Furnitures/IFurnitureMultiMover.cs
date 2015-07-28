using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureMultiMover : IBusinessService
    {
        void MoveAll(Room roomFrom, Room roomTo, DateTime date);
    }
}