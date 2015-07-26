using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureCreator : IBusinessService
    {
        Furniture Create(string type, DateTime date, string roomName, int count);

        Furniture Create(string type, DateTime date, int roomId, int count);
    }
}