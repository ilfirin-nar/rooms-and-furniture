using System;
using System.Web.Mvc;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomWebHandler handler;

        public HomeController(IRoomWebHandler handler)
        {
            this.handler = handler;
        }

        public ActionResult Index(DateTime? date)
        {
            var roomsClientsList = handler.Get(date).Data;
            ViewBag.CurrentDate = date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
            return View(new HomeClientModel(roomsClientsList));
        }

        public ActionResult AddRoomDialog()
        {
            return PartialView("AddRoomDialog");
        }
    }
}