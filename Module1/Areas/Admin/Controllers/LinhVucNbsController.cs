using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Module1.Models;

namespace Module1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LinhVucNbsController : Controller
    {
        private readonly QLNBDBContext _context;

        public LinhVucNbsController(QLNBDBContext context)
        {
            _context = context;
        }

        // GET: Admin/LinhVucNbs
        public async Task<IActionResult> Index()
        {
              return _context.LinhVucNbs != null ? 
                          View(await _context.LinhVucNbs.ToListAsync()) :
                          Problem("Entity set 'QLNBDBContext.LinhVucNbs'  is null.");
        }

        // GET: Admin/LinhVucNbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LinhVucNbs == null)
            {
                return NotFound();
            }

            var linhVucNb = await _context.LinhVucNbs
                .FirstOrDefaultAsync(m => m.MaLinhVuc == id);
            if (linhVucNb == null)
            {
                return NotFound();
            }

            return View(linhVucNb);
        }

        // GET: Admin/LinhVucNbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LinhVucNbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLinhVuc,TenLinhVuc")] LinhVucNb linhVucNb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linhVucNb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linhVucNb);
        }

        // GET: Admin/LinhVucNbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LinhVucNbs == null)
            {
                return NotFound();
            }

            var linhVucNb = await _context.LinhVucNbs.FindAsync(id);
            if (linhVucNb == null)
            {
                return NotFound();
            }
            return View(linhVucNb);
        }

        // POST: Admin/LinhVucNbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLinhVuc,TenLinhVuc")] LinhVucNb linhVucNb)
        {
            if (id != linhVucNb.MaLinhVuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhVucNb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhVucNbExists(linhVucNb.MaLinhVuc))
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
            return View(linhVucNb);
        }

        // GET: Admin/LinhVucNbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LinhVucNbs == null)
            {
                return NotFound();
            }

            var linhVucNb = await _context.LinhVucNbs
                .FirstOrDefaultAsync(m => m.MaLinhVuc == id);
            if (linhVucNb == null)
            {
                return NotFound();
            }

            return View(linhVucNb);
        }

        // POST: Admin/LinhVucNbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LinhVucNbs == null)
            {
                return Problem("Entity set 'QLNBDBContext.LinhVucNbs'  is null.");
            }
            var linhVucNb = await _context.LinhVucNbs.FindAsync(id);
            if (linhVucNb != null)
            {
                _context.LinhVucNbs.Remove(linhVucNb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhVucNbExists(int id)
        {
          return (_context.LinhVucNbs?.Any(e => e.MaLinhVuc == id)).GetValueOrDefault();
        }
    }
}
