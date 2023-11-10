using Microsoft.AspNetCore.Mvc;

namespace Module1.Areas.Journalist.Controllers
{
    public class HomeController : Controller
    {
        [Area("Journalist")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
