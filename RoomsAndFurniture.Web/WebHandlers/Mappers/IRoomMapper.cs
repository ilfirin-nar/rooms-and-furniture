using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.WebHandlers.Mappers
{
    public interface IRoomMapper : IClientDataMapper
    {
        Room Map(string name, DateTime date);
    }
}