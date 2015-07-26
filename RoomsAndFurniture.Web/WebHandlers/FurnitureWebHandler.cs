using System;
using RoomsAndFurniture.Web.Business.Furnitures;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Models.Results.Rooms;

namespace RoomsAndFurniture.Web.WebHandlers
{
    internal class FurnitureWebHandler : IFurnitureWebHandler
    {
        private readonly IFurnitureAmountIncreaser amountIncreaser;

        public FurnitureWebHandler(IFurnitureAmountIncreaser amountIncreaser)
        {
            this.amountIncreaser = amountIncreaser;
        }

        public ResultBase Create(string type, string roomName, DateTime date)
        {
            try
            {
                amountIncreaser.Increase(type, date, roomName, 1);
            }
            catch (RoomNotFoundException exception)
            {
                return new RoomNotFoundResult(exception.RoomName, exception.Date);
            }
            return new SuccessResult();
        }
    }
}