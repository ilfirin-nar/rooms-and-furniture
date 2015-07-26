using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IRoomWebHandler : IWebHandler
    {
        ResultBase<RoomClientModel> Create(string name, DateTime date);

        ResultBase Remove(string name, string moveFurnitureToRoom, DateTime date);
    }
}