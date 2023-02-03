
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using komite.Data;
using komite.Models;
using System;

namespace komite.Controllers
{
    public class vaziatsController : Controller
    {
        private readonly komiteContext _context;

        public vaziatsController(komiteContext context)
        {
            _context = context;
        }

        // GET: vaziats
        public async Task<IActionResult> Index()
        {
              return View(await _context.vaziat.ToListAsync());
        }

        // GET: vaziats/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.vaziat == null)
            {
                return NotFound();
            }

            var vaziat = await _context.vaziat
                .FirstOrDefaultAsync(m => m.id_vaziat == id);
            if (vaziat == null)
            {
                return NotFound();
            }

            return View(vaziat);
        }

        // GET: vaziats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vaziats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_vaziat,onvan_vaziat")] vaziat vaziat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaziat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaziat);
        }

        // GET: vaziats/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.vaziat == null)
            {
                return NotFound();
            }

            var vaziat = await _context.vaziat.FindAsync(id);
            if (vaziat == null)
            {
                return NotFound();
            }
            return View(vaziat);
        }

        // POST: vaziats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_vaziat,onvan_vaziat")] vaziat vaziat)
        {
            if (id != vaziat.id_vaziat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaziat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!vaziatExists(vaziat.id_vaziat))
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
            return View(vaziat);
        }

        // GET: vaziats/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.vaziat == null)
            {
                return NotFound();
            }

            var vaziat = await _context.vaziat
                .FirstOrDefaultAsync(m => m.id_vaziat == id);
            if (vaziat == null)
            {
                return NotFound();
            }

            return View(vaziat);
        }

        // POST: vaziats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.vaziat == null)
            {
                return Problem("Entity set 'komiteContext.vaziat'  is null.");
            }
            var vaziat = await _context.vaziat.FindAsync(id);
            if (vaziat != null)
            {
                _context.vaziat.Remove(vaziat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool vaziatExists(long id)
        {
          return _context.vaziat.Any(e => e.id_vaziat == id);
        }
    }
}
