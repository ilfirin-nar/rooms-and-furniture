using System;
using System.Web.Mvc;
using RoomsAndFurniture.Web.Enums;

namespace RoomsAndFurniture.Web.Controllers
{
    public class FurnitureController : Controller
    {
        public ActionResult Create(string type, string roomName, DateTime date)
        {
            throw new NotImplementedException();
        }

        public ActionResult Move(string type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            throw new NotImplementedException();
        }

        public ActionResult Remove(string type, string roomName, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}