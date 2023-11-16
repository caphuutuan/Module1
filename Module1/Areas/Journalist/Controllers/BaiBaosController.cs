using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Module1.Helper;
using Module1.Models;

namespace Module1.Areas.Journalist.Controllers
{
    [Area("Journalist")]
    public class BaiBaosController : Controller
    {
        private readonly QLNBDBContext _context;

        public BaiBaosController(QLNBDBContext context)
        {
            _context = context;
        }

        // GET: Journalist/BaiBaos
        public async Task<IActionResult> Index()
        {
            var qLNBDBContext = _context.BaiBaos
                .Include(b => b.MaLvNavigation)
                .Include(b => b.MaTlNavigation)
                .Where(b=>b.UserId==2)
                .Include(b => b.User);

            return View(await qLNBDBContext.ToListAsync());
        }

        // GET: Journalist/BaiBaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BaiBaos == null)
            {
                return NotFound();
            }

            var baiBao = await _context.BaiBaos
                .Include(b => b.MaLvNavigation)
                .Include(b => b.MaTlNavigation)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.MaBb == id);
            if (baiBao == null)
            {
                return NotFound();
            }

            return View(baiBao);
        }

        // GET: Journalist/BaiBaos/Create
        public IActionResult Create()
        {
            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");
            return View();
        }

        // POST: Journalist/BaiBaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBb,MaTl,UserId,TenBb,NgayViet,NoiDung,NgayChinhSua,DanhGia,Status,MaLv,Thumb,Active")] BaiBao baiBao, IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                baiBao.Status = 0;
                baiBao.UserId = 2;
                baiBao.NgayViet = DateTime.Now;
                baiBao.DanhGia = 0;

                baiBao.TenBb = Utilities.ToTitleCase(baiBao.TenBb);
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(baiBao.TenBb) + extension;
                    baiBao.Thumb = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
                }
                if (string.IsNullOrEmpty(baiBao.Thumb))
                {
                    baiBao.Thumb = "placeholder.jpg";
                }

                _context.Add(baiBao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");

            return View(baiBao);
        }

        // GET: Journalist/BaiBaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BaiBaos == null)
            {
                return NotFound();
            }

            var baiBao = await _context.BaiBaos.FindAsync(id);
            if (baiBao == null)
            {
                return NotFound();
            }

            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");

            return View(baiBao);
        }

        // POST: Journalist/BaiBaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBb,MaTl,UserId,TenBb,NgayViet,NoiDung,NgayChinhSua,DanhGia,Status,MaLv,Thumb,Active")] BaiBao baiBao, IFormFile fThumb)
        {
            if (id != baiBao.MaBb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    baiBao.TenBb = Utilities.ToTitleCase(baiBao.TenBb);
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(baiBao.TenBb) + extension;
                        baiBao.Thumb = await Utilities.UploadFile(fThumb, @"products", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(baiBao.Thumb))
                    {
                        baiBao.Thumb = "placeholder.jpg";
                    }

                    baiBao.UserId = 2;
                    baiBao.NgayViet = baiBao.NgayViet;
                    baiBao.NgayChinhSua = DateTime.Now;
                    _context.Update(baiBao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaiBaoExists(baiBao.MaBb))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");

            return View(baiBao);
        }

        // GET: Journalist/BaiBaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BaiBaos == null)
            {
                return NotFound();
            }

            var baiBao = await _context.BaiBaos
                .Include(b => b.MaLvNavigation)
                .Include(b => b.MaTlNavigation)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.MaBb == id);
            if (baiBao == null)
            {
                return NotFound();
            }

            return View(baiBao);
        }

        // POST: Journalist/BaiBaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BaiBaos == null)
            {
                return Problem("Entity set 'QLNBDBContext.BaiBaos'  is null.");
            }
            var baiBao = await _context.BaiBaos.FindAsync(id);
            if (baiBao != null)
            {
                _context.BaiBaos.Remove(baiBao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaiBaoExists(int id)
        {
            return (_context.BaiBaos?.Any(e => e.MaBb == id)).GetValueOrDefault();
        }
    }
}
