using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.RoomStates
{
    public interface IRoomStateReader : IBusinessService
    {
        IList<RoomState> Get(DateTime? date = null);
    }
}