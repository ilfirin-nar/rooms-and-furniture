using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IFurnitureWebHandler : IWebHandler
    {
        ResultBase<FurnitureClientModel> Create(string type, string roomName, DateTime date, int count = 1);

        ResultBase<FurnitureClientModel> Move(string type, string roomNameFrom, string roomNameTo, DateTime date);
    }
}