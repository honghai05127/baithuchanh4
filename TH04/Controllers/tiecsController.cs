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
    public class tiecsController : Controller
    {
        private readonly RestaurantContext _context;

        public tiecsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: tiecs
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Tiecs.Include(t => t.kh);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: tiecs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiec = await _context.Tiecs
                .Include(t => t.kh)
                .FirstOrDefaultAsync(m => m.Matiec == id);
            if (tiec == null)
            {
                return NotFound();
            }

            return View(tiec);
        }

        // GET: tiecs/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.KhachHangs, "Makh", "Makh");
            return View();
        }

        // POST: tiecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matiec,Tentiec,Ngaydat,Makh")] tiec tiec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makh"] = new SelectList(_context.KhachHangs, "Makh", "Makh", tiec.Makh);
            return View(tiec);
        }

        // GET: tiecs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiec = await _context.Tiecs.FindAsync(id);
            if (tiec == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.KhachHangs, "Makh", "Makh", tiec.Makh);
            return View(tiec);
        }

        // POST: tiecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Matiec,Tentiec,Ngaydat,Makh")] tiec tiec)
        {
            if (id != tiec.Matiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tiecExists(tiec.Matiec))
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
            ViewData["Makh"] = new SelectList(_context.KhachHangs, "Makh", "Makh", tiec.Makh);
            return View(tiec);
        }

        // GET: tiecs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiec = await _context.Tiecs
                .Include(t => t.kh)
                .FirstOrDefaultAsync(m => m.Matiec == id);
            if (tiec == null)
            {
                return NotFound();
            }

            return View(tiec);
        }

        // POST: tiecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tiec = await _context.Tiecs.FindAsync(id);
            _context.Tiecs.Remove(tiec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tiecExists(string id)
        {
            return _context.Tiecs.Any(e => e.Matiec == id);
        }
    }
}
