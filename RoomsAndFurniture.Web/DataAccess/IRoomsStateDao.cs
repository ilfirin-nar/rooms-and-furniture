using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.DataAccess
{
    public interface IRoomsStateDao : IDao
    {
        IList<RoomState> Get(DateTime date);
    }
}