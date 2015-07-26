using System;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    public interface IRoomReader : IBusinessService
    {
        Room Get(string name, DateTime date);
    }
}