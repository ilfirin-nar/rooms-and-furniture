using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IFurnitureWebHandler : IWebHandler
    {
        ResultBase Create(string type, string roomName, DateTime date);
    }
}