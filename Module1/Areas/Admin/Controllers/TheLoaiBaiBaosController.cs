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
    public class TheLoaiBaiBaosController : Controller
    {
        private readonly QLNBDBContext _context;

        public TheLoaiBaiBaosController(QLNBDBContext context)
        {
            _context = context;
        }

        // GET: Admin/TheLoaiBaiBaos
        public async Task<IActionResult> Index()
        {
              return _context.TheLoaiBaiBaos != null ? 
                          View(await _context.TheLoaiBaiBaos.ToListAsync()) :
                          Problem("Entity set 'QLNBDBContext.TheLoaiBaiBaos'  is null.");
        }

        // GET: Admin/TheLoaiBaiBaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TheLoaiBaiBaos == null)
            {
                return NotFound();
            }

            var theLoaiBaiBao = await _context.TheLoaiBaiBaos
                .FirstOrDefaultAsync(m => m.MaTl == id);
            if (theLoaiBaiBao == null)
            {
                return NotFound();
            }

            return View(theLoaiBaiBao);
        }

        // GET: Admin/TheLoaiBaiBaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TheLoaiBaiBaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTl,TenTl")] TheLoaiBaiBao theLoaiBaiBao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theLoaiBaiBao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theLoaiBaiBao);
        }

        // GET: Admin/TheLoaiBaiBaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TheLoaiBaiBaos == null)
            {
                return NotFound();
            }

            var theLoaiBaiBao = await _context.TheLoaiBaiBaos.FindAsync(id);
            if (theLoaiBaiBao == null)
            {
                return NotFound();
            }
            return View(theLoaiBaiBao);
        }

        // POST: Admin/TheLoaiBaiBaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTl,TenTl")] TheLoaiBaiBao theLoaiBaiBao)
        {
            if (id != theLoaiBaiBao.MaTl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theLoaiBaiBao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheLoaiBaiBaoExists(theLoaiBaiBao.MaTl))
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
            return View(theLoaiBaiBao);
        }

        // GET: Admin/TheLoaiBaiBaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TheLoaiBaiBaos == null)
            {
                return NotFound();
            }

            var theLoaiBaiBao = await _context.TheLoaiBaiBaos
                .FirstOrDefaultAsync(m => m.MaTl == id);
            if (theLoaiBaiBao == null)
            {
                return NotFound();
            }

            return View(theLoaiBaiBao);
        }

        // POST: Admin/TheLoaiBaiBaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TheLoaiBaiBaos == null)
            {
                return Problem("Entity set 'QLNBDBContext.TheLoaiBaiBaos'  is null.");
            }
            var theLoaiBaiBao = await _context.TheLoaiBaiBaos.FindAsync(id);
            if (theLoaiBaiBao != null)
            {
                _context.TheLoaiBaiBaos.Remove(theLoaiBaiBao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheLoaiBaiBaoExists(int id)
        {
          return (_context.TheLoaiBaiBaos?.Any(e => e.MaTl == id)).GetValueOrDefault();
        }
    }
}
