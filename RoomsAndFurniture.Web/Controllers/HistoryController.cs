using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RoomsAndFurniture.Web.Models;

namespace RoomsAndFurniture.Web.Controllers
{
    public class HistoryController : Controller
    {
        public ActionResult Index(bool isShort = false)
        {
            var fake = new HistoryClientModel
            {
                IsShort = false,
                Events = new List<RoomEventClientData>
                {
                    new RoomEventClientData { Date = DateTime.Now, Description = "Создана комната \"Гостинная\""},
                    new RoomEventClientData { Date = DateTime.Now, Description = "Создан предмет мебели типа \"Стул\""},
                    new RoomEventClientData { Date = DateTime.Now, Description = "Создан предмет мебели типа \"Стул\""},
                    new RoomEventClientData { Date = DateTime.Now, Description = "Создан предмет мебели типа \"Стол\""},
                    new RoomEventClientData { Date = DateTime.Now, Description = "Удалена комната \"Гостинная\""}
                }
            };
            return View(fake);
        }
    }
}