using System.Web.Mvc;
using RoomsAndFurniture.Web.WebHandlers;

namespace RoomsAndFurniture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeWebHandler handler;

        public HomeController(IHomeWebHandler handler)
        {
            this.handler = handler;
        }

        public ActionResult Index()
        {
            var model = handler.Get();
            return View(model);
        }
    }
}