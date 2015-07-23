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
                        Name = "���������",
                        Furniture = new List<FurnitureClientModel>
                        {
                            new FurnitureClientModel { Id = 1, Count = 10, FurnitureType = "����"},
                            new FurnitureClientModel { Id = 2, Count = 436, FurnitureType = "����"},
                            new FurnitureClientModel { Id = 3, Count = 346, FurnitureType = "������"},
                            new FurnitureClientModel { Id = 4, Count = 54, FurnitureType = "�������"},
                        }
                    },
                    new RoomClientModel
                    {
                        Id = 2,
                        CreateDate = DateTime.Now,
                        Name = "�������",
                        Furniture = new List<FurnitureClientModel>
                        {
                            new FurnitureClientModel { Id = 5, Count = 3, FurnitureType = "����"},
                            new FurnitureClientModel { Id = 6, Count = 35, FurnitureType = "����"},
                            new FurnitureClientModel { Id = 7, Count = 65, FurnitureType = "������"},
                            new FurnitureClientModel { Id = 8, Count = 22, FurnitureType = "�������"},
                        }
                    }
                }
            };
        }
    }
}