﻿using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business
{
    public interface IRoomChecker : IService
    {
        void Check(Room room);
    }
}