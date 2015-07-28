using System;
using RoomsAndFurniture.Web.Infrastructure.ClientModels;

namespace RoomsAndFurniture.Web.Models.Results.Furnitures
{
    public class FurnitureNotFoundResult : FailResult<FurnitureClientModel>
    {
        private const string MessageTemplate =
            "Мебель типа {0} не существует в комнате {1} на дату {2}";

        public FurnitureNotFoundResult(string furnitureType, string roomName, DateTime date)
            : base(string.Format(MessageTemplate, furnitureType, roomName, date)) { }
    }
}