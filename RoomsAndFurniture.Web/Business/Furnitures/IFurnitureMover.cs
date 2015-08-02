using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureMover : IBusinessService
    {
        void Move(string type, string roomNameFrom, string roomNameTo, DateTime date);

        void Move(string roomFrom, string roomTo, DateTime date);
    }
}