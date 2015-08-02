using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Business.FurnitureLocations
{
    public interface IFurnitureLocationReader : IBusinessService
    {
        IList<FurnitureLocation> Get(string type, int roomId, DateTime date);
    }
}