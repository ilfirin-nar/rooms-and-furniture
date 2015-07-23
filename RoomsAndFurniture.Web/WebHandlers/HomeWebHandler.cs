using System;
using System.Collections.Generic;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.WebHandlers
{
    internal class HomeWebHandler : IHomeWebHandler
    {
        public HomeClientModel Get()
        {
            return new HomeClientModel
            {
                Rooms = new List<RoomClientModel> {
                    new RoomClientModel
                    {
                        Id = 1,
                        CreateDate = DateTime.Now,
                        Name = "Гостинная",
                        Furniture = new List<FurnitureClientModel>
                        {
                            new FurnitureClientModel { Id = 1, Count = 10, FurnitureType = "Стол"},
                            new FurnitureClientModel { Id = 2, Count = 436, FurnitureType = "Стул"},
                            new FurnitureClientModel { Id = 3, Count = 346, FurnitureType = "Кресло"},
                            new FurnitureClientModel { Id = 4, Count = 54, FurnitureType = "Кровать"},
                        }
                    },
                    new RoomClientModel
                    {
                        Id = 2,
                        CreateDate = DateTime.Now,
                        Name = "Спальня",
                        Furniture = new List<FurnitureClientModel>
                        {
                            new FurnitureClientModel { Id = 5, Count = 3, FurnitureType = "Стол"},
                            new FurnitureClientModel { Id = 6, Count = 35, FurnitureType = "Стул"},
                            new FurnitureClientModel { Id = 7, Count = 65, FurnitureType = "Кресло"},
                            new FurnitureClientModel { Id = 8, Count = 22, FurnitureType = "Кровать"},
                        }
                    }
                }
            };
        }
    }
}