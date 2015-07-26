using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureMover : IBusinessService
    {
        Furniture Move(string type, string roomNameFrom, string roomNameTo, DateTime date);
    }
}