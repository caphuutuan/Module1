using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module1.Models;
using System.Diagnostics;

namespace Module1.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNBDBContext _context;

        public HomeController(QLNBDBContext context)
        {
            _context = context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            var qLNBDBContext = _context.BaiBaos.Include(b => b.MaLvNavigation).Include(b => b.MaTlNavigation).Include(b => b.User).Where(b => b.Status == 1).Where(b=>b.Active==true);
            return View(await qLNBDBContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}