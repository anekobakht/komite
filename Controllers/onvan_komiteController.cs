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
    public class onvan_komiteController : Controller
    {
        private readonly komiteContext _context;

        public onvan_komiteController(komiteContext context)
        {
            _context = context;
        }

        // GET: onvan_komite
        public async Task<IActionResult> Index()
        {
            try
            {
            return View(await _context.onvan_komite.Where(s => s.id_user.ToString() == HttpContext.Session.GetString("")).ToListAsync()); 
            }
            catch
            {
                return View(await _context.onvan_komite.ToListAsync());
            }
        }

        public async Task<IActionResult> Index_user()
        {
            var q = _context.onvan_komite.Where(s => s.id_user == Int64.Parse(HttpContext.Session.GetString("id_user")));
            return View(await q.ToListAsync());
        } 

        public async Task<IActionResult> Mosavabat(int id)
        {
            HttpContext.Session.SetString("id_onvan_komite",id.ToString());
            return RedirectToAction("Index","sabts");
        }

        // GET: onvan_komite/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.onvan_komite == null)
            {
                return NotFound(); 
            }

            var onvan_komite = await _context.onvan_komite
                .FirstOrDefaultAsync(m => m.id_onvan_komite == id);
            if (onvan_komite == null)
            {
                return NotFound();
            }
             
            return View(onvan_komite);
        }

        // GET: onvan_komite/Create
        public IActionResult Create()
        {
            ViewBag.id_user = new SelectList(_context.user, "id_user", "name");
            return View();
        }

        // POST: onvan_komite/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Int64 id_user,[Bind("id_onvan_komite,name")] onvan_komite onvan_komite)
        {
            onvan_komite.id_user = id_user;
            if (ModelState.IsValid)
            {
                _context.Add(onvan_komite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onvan_komite);
        }

        // GET: onvan_komite/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            ViewBag.id_user = new SelectList(_context.user, "id_user", "name");
            if (id == null || _context.onvan_komite == null)
            {
                return NotFound();
            }

            var onvan_komite = await _context.onvan_komite.FindAsync(id);
            if (onvan_komite == null)
            {
                return NotFound();
            }
            return View(onvan_komite);
        }

        // POST: onvan_komite/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int64 id_user, long id, [Bind("id_onvan_komite,name")] onvan_komite onvan_komite)
        {
            if (id != onvan_komite.id_onvan_komite)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    onvan_komite.id_user=id_user;
                    _context.Update(onvan_komite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!onvan_komiteExists(onvan_komite.id_onvan_komite))
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
            return View(onvan_komite);
        }

        // GET: onvan_komite/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.onvan_komite == null)
            {
                return NotFound();
            }

            var onvan_komite = await _context.onvan_komite
                .FirstOrDefaultAsync(m => m.id_onvan_komite == id);
            if (onvan_komite == null)
            {
                return NotFound();
            }

            return View(onvan_komite);
        }

        // POST: onvan_komite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.onvan_komite == null)
            {
                return Problem("Entity set 'komiteContext.onvan_komite'  is null.");
            }
            var onvan_komite = await _context.onvan_komite.FindAsync(id);
            if (onvan_komite != null)
            {
                _context.onvan_komite.Remove(onvan_komite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool onvan_komiteExists(long id)
        {
          return _context.onvan_komite.Any(e => e.id_onvan_komite == id);
        }
    }
}
