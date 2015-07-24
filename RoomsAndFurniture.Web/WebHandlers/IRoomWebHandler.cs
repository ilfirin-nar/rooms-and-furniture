using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IRoomWebHandler : IWebHandler
    {
        RoomClientModel Create(string name, DateTime date);
    }
}