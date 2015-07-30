using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureAmountIncreaser : IBusinessService
    {
        FurnitureState Increase(string type, DateTime date, string roomName, int increaseBy);
    }
}