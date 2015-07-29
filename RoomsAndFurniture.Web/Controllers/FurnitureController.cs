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

        public ActionResult Create(string type, string roomName, DateTime date, int count = 1)
        {
            return Json(handler.Create(type, roomName, date, count), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            return Json(handler.Move(type, roomNameFrom, roomNameTo, date), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remove(string type, string roomName, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}