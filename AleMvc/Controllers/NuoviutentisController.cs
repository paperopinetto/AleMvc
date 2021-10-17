using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AleMvc.Data;
using AleMvc.Models;

namespace AleMvc
{
    public class NuoviutentisController : Controller
    {
        private readonly MioDbContext _context;

        public NuoviutentisController(MioDbContext context)
        {
            _context = context;
        }

        // GET: Nuoviutentis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nuoviutentis.ToListAsync());
        }

        // GET: Nuoviutentis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuoviutenti = await _context.Nuoviutentis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nuoviutenti == null)
            {
                return NotFound();
            }

            return View(nuoviutenti);
        }

        // GET: Nuoviutentis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nuoviutentis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Password")] Nuoviutenti nuoviutenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nuoviutenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nuoviutenti);
        }

        // GET: Nuoviutentis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuoviutenti = await _context.Nuoviutentis.FindAsync(id);
            if (nuoviutenti == null)
            {
                return NotFound();
            }
            return View(nuoviutenti);
        }

        // POST: Nuoviutentis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Password")] Nuoviutenti nuoviutenti)
        {
            if (id != nuoviutenti.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nuoviutenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NuoviutentiExists(nuoviutenti.ID))
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
            return View(nuoviutenti);
        }

        // GET: Nuoviutentis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nuoviutenti = await _context.Nuoviutentis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nuoviutenti == null)
            {
                return NotFound();
            }

            return View(nuoviutenti);
        }

        // POST: Nuoviutentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nuoviutenti = await _context.Nuoviutentis.FindAsync(id);
            _context.Nuoviutentis.Remove(nuoviutenti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NuoviutentiExists(int id)
        {
            return _context.Nuoviutentis.Any(e => e.ID == id);
        }
    }
}
