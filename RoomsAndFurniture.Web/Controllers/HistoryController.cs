using System.Web.Mvc;
using RoomsAndFurniture.Web.Models;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryWebHandler handler;

        public HistoryController(IHistoryWebHandler handler)
        {
            this.handler = handler;
        }

        public ActionResult Index(bool isShort = false)
        {
            var data = handler.Get().Data;
            return View(new HistoryClientModel(data));
        }
    }
}