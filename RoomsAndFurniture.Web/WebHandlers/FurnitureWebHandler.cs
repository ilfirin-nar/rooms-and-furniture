using System;
using RoomsAndFurniture.Web.Business.Furnitures;
using RoomsAndFurniture.Web.Business.Furnitures.Exceptions;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.Models.Results.Furnitures;
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

        public ResultBase<FurnitureClientModel> Create(string type, string roomName, DateTime date, int count = 1)
        {
            try
            {
                var furniture = amountIncreaser.Increase(type, date, roomName, count);
                return new SuccessResult<FurnitureClientModel>(furniture.MapTo<FurnitureClientModel>());
            }
            catch (RoomNotFoundException exception)
            {
                return new RoomNotFoundResult<FurnitureClientModel>(exception.RoomName, exception.Date);
            }
        }

        public ResultBase<FurnitureClientModel> Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            try
            {
                var furniture = furnitureMover.Move(type, roomNameFrom, roomNameTo, date);
                return new SuccessResult<FurnitureClientModel>(furniture.MapTo<FurnitureClientModel>());
            }
            catch (FurnitureNotFoundException e)
            {
                return new FurnitureNotFoundResult(e.FurnitureType, e.RoomName, e.Date);
            }
            catch (RoomNotFoundException e)
            {
                return new RoomNotFoundResult<FurnitureClientModel>(e.RoomName, e.Date);
            }
        }
    }
}