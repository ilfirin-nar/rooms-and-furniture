using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IRoomWebHandler : IWebHandler
    {
        ResultBase<IList<RoomClientModel>> Get(DateTime? date = null);

        ResultBase<RoomClientModel> Create(string name, DateTime date);

        ResultBase Remove(string name, string roomTo, DateTime date);

        ResultBase RemoveWithoutMovig(string name, DateTime date);
    }
}