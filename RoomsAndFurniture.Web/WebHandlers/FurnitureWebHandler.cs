using System;
using RoomsAndFurniture.Web.Business.Furnitures;
using RoomsAndFurniture.Web.Business.Furnitures.Exceptions;
using RoomsAndFurniture.Web.Business.Rooms.Exceptions;
using RoomsAndFurniture.Web.Domain;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;
using RoomsAndFurniture.Web.Infrastructure.Extensions;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.Models.Results.Furnitures;
using RoomsAndFurniture.Web.Models.Results.Rooms;

namespace RoomsAndFurniture.Web.WebHandlers
{
    internal class FurnitureWebHandler : IFurnitureWebHandler
    {
        private readonly IFurnitureAdder furnitureAdder;
        private readonly IFurnitureMover furnitureMover;

        public FurnitureWebHandler(
            IFurnitureAdder furnitureAdder,
            IFurnitureMover furnitureMover)
        {
            this.furnitureAdder = furnitureAdder;
            this.furnitureMover = furnitureMover;
        }

        public ResultBase<FurnitureClientModel> Create(string type, string roomName, DateTime date, int count = 1)
        {
            try
            {
                var furnitureState = furnitureAdder.Add(new Furniture(date, type), roomName);
                return new SuccessResult<FurnitureClientModel>(furnitureState.MapTo<FurnitureClientModel>());
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
                furnitureMover.Move(type, roomNameFrom, roomNameTo, date);
                return new SuccessResult<FurnitureClientModel>();
            }
            catch (FurnitureNotFoundException e)
            {
                return new FurnitureNotFoundResult(e.FurnitureType, roomNameFrom, e.Date);
            }
            catch (RoomNotFoundException e)
            {
                return new RoomNotFoundResult<FurnitureClientModel>(e.RoomName, e.Date);
            }
            catch (InvalidFurnitureMovingException)
            {
                return new InvalidFurnitureMovingResult();
            }
        }
    }
}