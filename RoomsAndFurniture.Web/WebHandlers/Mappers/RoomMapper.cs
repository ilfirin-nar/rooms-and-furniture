using System.Collections.Generic;
using System.Linq;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers.Mappers
{
    internal class RoomMapper : IRoomMapper
    {
        public RoomClientModel Map(Room room)
        {
            return new RoomClientModel
            {
                RoomId = room.Id,
                Date = room.CreateDate.ToString("dd'.'MM'.'yyyy"),
                RoomName = room.Name
            };
        }

        public IList<RoomClientModel> Map(IList<RoomState> items)
        {
            return items.Select(Map).ToList();
        }

        public RoomClientModel Map(RoomState item)
        {
            var result = item.MapTo<RoomClientModel>();
            result.Date = item.Date.ToString("dd'.'MM'.'yyyy");
            result.FurnitureItems = item.FurnitureItems.Select(i => i.MapTo<FurnitureClientModel>()).ToList();
            return result;
        }
    }
}