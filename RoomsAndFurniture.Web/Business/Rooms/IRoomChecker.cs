using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    public interface IRoomChecker : IBusinessService
    {
        bool IsExists(Room room, DateTime date);
    }
}