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
        private readonly IFurnitureMover furnitureMover;

        public FurnitureWebHandler(
            IFurnitureAmountIncreaser amountIncreaser,
            IFurnitureMover furnitureMover)
        {
            this.amountIncreaser = amountIncreaser;
            this.furnitureMover = furnitureMover;
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

        public ResultBase Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            try
            {
                furnitureMover.Move(type, roomNameFrom, roomNameTo, date);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}