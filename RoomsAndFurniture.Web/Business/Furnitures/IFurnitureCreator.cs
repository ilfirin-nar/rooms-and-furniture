using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    public interface IFurnitureCreator : IBusinessService
    {
        FurnitureState Create(string type, DateTime date, string roomName, int count);

        FurnitureState Create(string type, DateTime date, int roomId, int count);

        void Create(IList<FurnitureState> furnitureItems);
    }
}