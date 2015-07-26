using System;
using System.Web.Mvc;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Controllers
{
    public class FurnitureController : Controller
    {
        private readonly IFurnitureWebHandler handler;

        public FurnitureController(IFurnitureWebHandler handler)
        {
            this.handler = handler;
        }

        public ActionResult Create(string type, string roomName, DateTime date)
        {
            return Json(handler.Create(type, roomName, date));
        }

        public ActionResult Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            return Json(null);
        }

        public ActionResult Remove(string type, string roomName, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}