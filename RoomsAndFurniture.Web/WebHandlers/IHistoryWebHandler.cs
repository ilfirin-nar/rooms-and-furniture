using System.Collections.Generic;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    public interface IHistoryWebHandler : IWebHandler
    {
        ResultBase<IList<RoomEventClientData>> Get(bool isShort = false);
    }
}