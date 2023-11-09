using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Module1.Models;

namespace Module1.Controllers
{
    public class SitesController : Controller
    {
        private readonly QLNBDBContext _context;

        public SitesController(QLNBDBContext context)
        {
            _context = context;
        }
        // GET: BaiBaosController
        public ActionResult Index()
        {
            //List<BaiBao> baiBaos = _context.BaiBaos.Where(m => m.Status == 1).ToList();
            //ViewBag.AuthorList = new ;

            //return View();

            ViewBag.NewProduct = _context.BaiBaos.Where(m => m.Status == 1).ToList();
            ViewBag.PromotionProduct = _context.BaiBaos.Where(m => m.Status == 1).ToList();
            return View("Home", _context.BaiBaos.Where(m => m.Status == 1).ToList());
        }

    }
}
