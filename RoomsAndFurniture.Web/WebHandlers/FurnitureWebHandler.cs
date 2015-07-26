using System;
using RoomsAndFurniture.Web.Business.Furnitures;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;
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

        public ResultBase<FurnitureClientModel> Create(string type, string roomName, DateTime date)
        {
            try
            {
                var furniture = amountIncreaser.Increase(type, date, roomName, 1);
                return new SuccessResult<FurnitureClientModel>(furniture.MapTo<FurnitureClientModel>());
            }
            catch (RoomNotFoundException exception)
            {
                return new RoomNotFoundResult(exception.RoomName, exception.Date);
            }
        }
    }
}