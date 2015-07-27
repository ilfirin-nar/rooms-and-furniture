using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Infrastructure.CommonInterfaces;

namespace RoomsAndFurniture.Web.Criterions.FurnitureCriterions
{
    public class GetFurnitureItemsByRoomsIdsAndDateCriterion : ICriterion
    {
        public IList<int> RoomsIds { get; set; }

        public DateTime Date { get; set; }

        public GetFurnitureItemsByRoomsIdsAndDateCriterion(IList<int> roomsIds, DateTime date)
        {
            RoomsIds = roomsIds;
            Date = date;
        }
    }
}