using System;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.Rooms
{
    public interface IRoomRemover : IBusinessService
    {
        void Remove(string name, string roomTo, DateTime date);
    }
}