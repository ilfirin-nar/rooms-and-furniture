using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers.Mappers
{
    public interface IRoomMapper : IClientDataMapper
    {
        RoomClientModel Map(Room room);

        IList<RoomClientModel> Map(IList<RoomState> items);

        RoomClientModel Map(RoomState item);
    }
}