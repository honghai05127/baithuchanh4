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
    public class bookphongsController : Controller
    {
        private readonly RestaurantContext _context;

        public bookphongsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: bookphongs
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.BookPhongs.Include(b => b.ph).Include(b => b.tc);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: bookphongs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookphong = await _context.BookPhongs
                .Include(b => b.ph)
                .Include(b => b.tc)
                .FirstOrDefaultAsync(m => m.Matiec == id);
            if (bookphong == null)
            {
                return NotFound();
            }

            return View(bookphong);
        }

        // GET: bookphongs/Create
        public IActionResult Create()
        {
            ViewData["Maphong"] = new SelectList(_context.Phongs, "Maphong", "Maphong");
            ViewData["Matiec"] = new SelectList(_context.Tiecs, "Matiec", "Matiec");
            return View();
        }

        // POST: bookphongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Slnuocuong,Maphong,Matiec")] bookphong bookphong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookphong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maphong"] = new SelectList(_context.Phongs, "Maphong", "Maphong", bookphong.Maphong);
            ViewData["Matiec"] = new SelectList(_context.Tiecs, "Matiec", "Matiec", bookphong.Matiec);
            return View(bookphong);
        }

        // GET: bookphongs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookphong = await _context.BookPhongs.FindAsync(id);
            if (bookphong == null)
            {
                return NotFound();
            }
            ViewData["Maphong"] = new SelectList(_context.Phongs, "Maphong", "Maphong", bookphong.Maphong);
            ViewData["Matiec"] = new SelectList(_context.Tiecs, "Matiec", "Matiec", bookphong.Matiec);
            return View(bookphong);
        }

        // POST: bookphongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Slnuocuong,Maphong,Matiec")] bookphong bookphong)
        {
            if (id != bookphong.Matiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookphong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bookphongExists(bookphong.Matiec))
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
            ViewData["Maphong"] = new SelectList(_context.Phongs, "Maphong", "Maphong", bookphong.Maphong);
            ViewData["Matiec"] = new SelectList(_context.Tiecs, "Matiec", "Matiec", bookphong.Matiec);
            return View(bookphong);
        }

        // GET: bookphongs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookphong = await _context.BookPhongs
                .Include(b => b.ph)
                .Include(b => b.tc)
                .FirstOrDefaultAsync(m => m.Matiec == id);
            if (bookphong == null)
            {
                return NotFound();
            }

            return View(bookphong);
        }

        // POST: bookphongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bookphong = await _context.BookPhongs.FindAsync(id);
            _context.BookPhongs.Remove(bookphong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bookphongExists(string id)
        {
            return _context.BookPhongs.Any(e => e.Matiec == id);
        }
    }
}
