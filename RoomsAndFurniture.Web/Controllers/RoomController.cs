using System;
using System.Web.Mvc;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomWebHandler handler;

        public RoomController(IRoomWebHandler handler)
        {
            this.handler = handler;
        }

        public ActionResult Get(DateTime? date = null)
        {
            return Json(handler.Get(date));
        }

        public ActionResult Create(string name, DateTime date)
        {
            return Json(handler.Create(name, date));
        }

        public ActionResult Remove(string name, string moveFurnitureTo, DateTime date)
        {
            return Json(handler.Remove(name, moveFurnitureTo, date));
        }
    }
}