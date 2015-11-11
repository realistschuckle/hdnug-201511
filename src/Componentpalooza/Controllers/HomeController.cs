using Microsoft.AspNet.Mvc;

namespace Componentpalooza.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Calendar!";
            return View("Index");
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
