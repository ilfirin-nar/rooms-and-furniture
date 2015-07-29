using System;
using System.Web.Mvc;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomWebHandler handler;
        private readonly IDatabaseInitializer databaseInitializer;

        public HomeController(IRoomWebHandler handler, IDatabaseInitializer databaseInitializer)
        {
            this.handler = handler;
            this.databaseInitializer = databaseInitializer;
        }

        public ActionResult Index(DateTime? date)
        {
            var roomsClientsList = handler.Get(date).Data;
            ViewBag.CurrentDate = date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
            return View(new HomeClientModel(roomsClientsList));
        }

        public ActionResult RecreateDatabase()
        {
            databaseInitializer.Recreate();
            return RedirectToAction("Index");
        }
    }
}