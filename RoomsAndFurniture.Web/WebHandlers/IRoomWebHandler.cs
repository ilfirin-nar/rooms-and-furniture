using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IRoomWebHandler : IWebHandler
    {
        ClientData<RoomClientModel> Create(string name, DateTime date);
    }
}