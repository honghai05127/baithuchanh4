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
    public class sanhsController : Controller
    {
        private readonly RestaurantContext _context;

        public sanhsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: sanhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sanhs.ToListAsync());
        }

        // GET: sanhs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanh = await _context.Sanhs
                .FirstOrDefaultAsync(m => m.Masanh == id);
            if (sanh == null)
            {
                return NotFound();
            }

            return View(sanh);
        }

        // GET: sanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masanh,Tensanh")] sanh sanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanh);
        }

        // GET: sanhs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanh = await _context.Sanhs.FindAsync(id);
            if (sanh == null)
            {
                return NotFound();
            }
            return View(sanh);
        }

        // POST: sanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masanh,Tensanh")] sanh sanh)
        {
            if (id != sanh.Masanh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sanhExists(sanh.Masanh))
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
            return View(sanh);
        }

        // GET: sanhs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanh = await _context.Sanhs
                .FirstOrDefaultAsync(m => m.Masanh == id);
            if (sanh == null)
            {
                return NotFound();
            }

            return View(sanh);
        }

        // POST: sanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanh = await _context.Sanhs.FindAsync(id);
            _context.Sanhs.Remove(sanh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sanhExists(string id)
        {
            return _context.Sanhs.Any(e => e.Masanh == id);
        }
    }
}
