using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TH04.Data;
using TH04.Models;

namespace TH04.Controllers
{
    public class phongsController : Controller
    {
        private readonly RestaurantContext _context;

        public phongsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: phongs
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Phongs.Include(p => p.sanh);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: phongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.sanh)
                .FirstOrDefaultAsync(m => m.Maphong == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // GET: phongs/Create
        public IActionResult Create()
        {
            ViewData["Masanh"] = new SelectList(_context.Sanhs, "Masanh", "Masanh");
            return View();
        }

        // POST: phongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maphong,Tenphong,Succhua,Loaiphong,Masanh")] phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Masanh"] = new SelectList(_context.Sanhs, "Masanh", "Masanh", phong.Masanh);
            return View(phong);
        }

        // GET: phongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewData["Masanh"] = new SelectList(_context.Sanhs, "Masanh", "Masanh", phong.Masanh);
            return View(phong);
        }

        // POST: phongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Maphong,Tenphong,Succhua,Loaiphong,Masanh")] phong phong)
        {
            if (id != phong.Maphong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!phongExists(phong.Maphong))
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
            ViewData["Masanh"] = new SelectList(_context.Sanhs, "Masanh", "Masanh", phong.Masanh);
            return View(phong);
        }

        // GET: phongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.sanh)
                .FirstOrDefaultAsync(m => m.Maphong == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            _context.Phongs.Remove(phong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool phongExists(string id)
        {
            return _context.Phongs.Any(e => e.Maphong == id);
        }
    }
}
