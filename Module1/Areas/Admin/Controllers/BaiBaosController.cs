﻿using System;
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
    public class BaiBaosController : Controller
    {
        private readonly QLNBDBContext _context;

        public BaiBaosController(QLNBDBContext context)
        {
            _context = context;
        }

        // GET: Admin/BaiBaos
        public async Task<IActionResult> Index()
        {
            var qLNBDBContext = _context.BaiBaos
                .Include(b => b.MaLvNavigation)
                .Include(b => b.MaTlNavigation)
                .Include(b => b.User);
            return View(await qLNBDBContext.ToListAsync());
        }

        // GET: Admin/BaiBaos/Details/5
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

        // GET: Admin/BaiBaos/Create
        public IActionResult Create()
        {
            //ViewData["MaLv"] = new SelectList(_context.LinhVucNbs, "MaLinhVuc", "TenLinhVuc");
            //ViewData["MaTl"] = new SelectList(_context.TheLoaiBaiBaos, "MaTl", "TenTl");
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Ten");

            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");



            return View();
        }

        // POST: Admin/BaiBaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBb,MaTl,UserId,TenBb,NgayViet,NoiDung,NgayChinhSua,DanhGia,Status,MaLv")] BaiBao baiBao)
        {
            if (ModelState.IsValid)
            {
                baiBao.Status = 2;
                baiBao.Active = false;
                baiBao.NgayViet = DateTime.Now;
                baiBao.DanhGia = 0;
                _context.Add(baiBao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MaLv"] = new SelectList(_context.LinhVucNbs, "MaLinhVuc", "MaLinhVuc", baiBao.MaLv);
            //ViewData["MaTl"] = new SelectList(_context.TheLoaiBaiBaos, "MaTl", "MaTl", baiBao.MaTl);
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", baiBao.UserId);

            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");



            return View(baiBao);
        }

        public IActionResult DuyetBai(int id)
        {
            // Xác nhận và duyệt bài viết
            var baiBao = _context.BaiBaos.Find(id);
            if (baiBao != null)
            {
                baiBao.Status = 1;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //public IActionResult TuChoiBai(int id)
        //{
        //    // Từ chối bài viết
        //    var baiBao = _context.BaiBaos.Find(id);
        //    if (baiBao != null)
        //    {
        //        baiBao.Status = 2;
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}

        // GET: Admin/BaiBaos/Edit/5
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
            //ViewData["MaLv"] = new SelectList(_context.LinhVucNbs, "MaLinhVuc", "MaLinhVuc", baiBao.MaLv);
            //ViewData["MaTl"] = new SelectList(_context.TheLoaiBaiBaos, "MaTl", "MaTl", baiBao.MaTl);
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", baiBao.UserId);

            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");

            return View(baiBao);
        }

        // POST: Admin/BaiBaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBb,MaTl,UserId,TenBb,NgayViet,NoiDung,NgayChinhSua,DanhGia,Status,MaLv")] BaiBao baiBao)
        {
            if (id != baiBao.MaBb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            //ViewData["MaLv"] = new SelectList(_context.LinhVucNbs, "MaLinhVuc", "MaLinhVuc", baiBao.MaLv);
            //ViewData["MaTl"] = new SelectList(_context.TheLoaiBaiBaos, "MaTl", "MaTl", baiBao.MaTl);
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", baiBao.UserId);

            List<User> tacgia = _context.Users.Where(u => u.RoleId == 3).ToList();
            ViewBag.AuthorList = new SelectList(tacgia, "UserId", "Ten");

            List<TheLoaiBaiBao> theLoaiBaiBaos = _context.TheLoaiBaiBaos.ToList();
            ViewBag.CategoryList = new SelectList(theLoaiBaiBaos, "MaTl", "TenTl");

            List<LinhVucNb> linhvuc = _context.LinhVucNbs.ToList();
            ViewBag.LinhVucList = new SelectList(linhvuc, "MaLinhVuc", "TenLinhVuc");

            return View(baiBao);
        }

        // GET: Admin/BaiBaos/Delete/5
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

        // POST: Admin/BaiBaos/Delete/5
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
