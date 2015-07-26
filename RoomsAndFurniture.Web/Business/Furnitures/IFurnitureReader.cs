using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureReader : IBusinessService
    {
        Furniture Get(string type, DateTime date, string roomName);
    }
}