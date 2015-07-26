using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureAmountIncreaser : IBusinessService
    {
        int Increase(string type, DateTime date, string roomName, int increaseBy);
    }
}