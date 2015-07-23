using System;
using System.Web.Mvc;
using RoomsAndFurniture.Web.Enums;

namespace RoomsAndFurniture.Web.Controllers
{
    public class FurnitureController : Controller
    {
        public ActionResult Create(FurnitureType type, string roomName, DateTime date)
        {
            throw new NotImplementedException();
        }

        public ActionResult Move(FurnitureType type, string roomNameFrom, string roomNameTo, DateTime date)
        {
            throw new NotImplementedException();
        }

        public ActionResult Remove(FurnitureType type, string roomName, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}