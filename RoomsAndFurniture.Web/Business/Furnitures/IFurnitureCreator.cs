using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureCreator : IBusinessService
    {
        int Create(string type, DateTime date, string roomName, int count);
    }
}