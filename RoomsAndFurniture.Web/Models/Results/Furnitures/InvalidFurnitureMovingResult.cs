using RoomsAndFurniture.Web.Infrastructure.ClientModels;

namespace RoomsAndFurniture.Web.Models.Results.Furnitures
{
    public class InvalidFurnitureMovingResult : FailResult<FurnitureClientModel>
    {
        private const string MessageTemplate = "Невозможно переместить в ту же самую комнату";

        public InvalidFurnitureMovingResult() : base(string.Format(MessageTemplate)) {}
    }
}