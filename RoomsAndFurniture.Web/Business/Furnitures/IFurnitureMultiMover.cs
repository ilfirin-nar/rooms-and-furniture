using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureMultiMover : IBusinessService
    {
        void MoveAll(string roomFrom, string roomTo, DateTime date);
    }
}