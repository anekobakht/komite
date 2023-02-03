using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using komite.Data;
using komite.Models;

namespace komite.Controllers
{
    public class sabtsController : Controller
    {
        private readonly komiteContext _context;

        public sabtsController(komiteContext context)
        {
            _context = context;
        }

        // GET: sabts
        public async Task<IActionResult> Index()
        {
            var q1 = _context.onvan_komite.AsNoTracking().Where(s => s.id_onvan_komite == Int64.Parse(HttpContext.Session.GetString("id_onvan_komite"))).FirstOrDefault();
            ViewBag.name = q1.name;
            var q = _context.v_sabt.Where(s => s.id_onvan_komite == int.Parse(HttpContext.Session.GetString("id_onvan_komite")));
            return View(await q.ToListAsync());
        }

        // GET: sabts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.sabt == null)
            {
                return NotFound();
            }

            var sabt = await _context.sabt
                .FirstOrDefaultAsync(m => m.id_sabt == id);
            if (sabt == null)
            {
                return NotFound();
            }

            return View(sabt);
        }

        // GET: sabts/Create
        public IActionResult Create()
        {
            ViewBag.id_vaziat = new SelectList(_context.vaziat, "id_vaziat", "onvan_vaziat");
            ViewBag.id_onvan_komite = HttpContext.Session.GetString("id_onvan_komite");
            return View();
        }

        // POST: sabts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id_vaziat, [Bind("id_sabt,onvan,date_jalase,masul_anjam,masul_peygiri,date_shoru,date_mohlat,id_vaziat,tozihat,darsad,id_onvan_komite")] sabt sabt)
        {

            if (id_vaziat == 1)
            {
                sabt.darsad = 50;
            }
            else if (id_vaziat == 2)
            {
                sabt.darsad = 100;
            }
            else
            {
                sabt.darsad = 0;
            }
            sabt.id_vaziat = id_vaziat;
            sabt.id_onvan_komite = int.Parse(HttpContext.Session.GetString("id_onvan_komite"));
            _context.Add(sabt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: sabts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            ViewBag.id_vaziat = new SelectList(_context.vaziat, "id_vaziat", "onvan_vaziat");
            if (id == null || _context.sabt == null)
            {
                return NotFound();
            }

            var sabt = await _context.v_sabt.FindAsync(id);
            if (sabt == null)
            {
                return NotFound();
            }
            return View(sabt);
        }

        // POST: sabts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id_vaziat, long id, [Bind("id_sabt,onvan,date_jalase,masul_anjam,masul_peygiri,date_shoru,date_mohlat,id_vaziat,tozihat,darsad,id_onvan_komite")] sabt sabt)
        {

            if (id_vaziat == 1)
            {
                sabt.darsad = 50;
            }
            else if (id_vaziat == 2)
            {
                sabt.darsad = 100;
            }
            else
            {
                sabt.darsad = 0;
            }
            sabt.id_vaziat = id_vaziat;

            if (id != sabt.id_sabt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sabt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sabtExists(sabt.id_sabt))
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
            return View(sabt);
        }

        // GET: sabts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.sabt == null)
            {
                return NotFound();
            }

            var sabt = await _context.sabt
                .FirstOrDefaultAsync(m => m.id_sabt == id);
            if (sabt == null)
            {
                return NotFound();
            }

            return View(sabt);
        }

        // POST: sabts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.sabt == null)
            {
                return Problem("Entity set 'komiteContext.sabt'  is null.");
            }
            var sabt = await _context.sabt.FindAsync(id);
            if (sabt != null)
            {
                _context.sabt.Remove(sabt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sabtExists(long id)
        {
            return _context.sabt.Any(e => e.id_sabt == id);
        }
    }
}
