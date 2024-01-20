using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hypta_Projekt.Data;
using Hypta_Projekt.Models;

namespace Hypta_Projekt.Controllers
{
    public class ZamowieniaController : Controller
    {
        private readonly Hypta_ProjektContext _context;

        public ZamowieniaController(Hypta_ProjektContext context)
        {
            _context = context;
        }

        // GET: Zamowienia
        public async Task<IActionResult> Index()
        {
            var hypta_ProjektContext = _context.Zamowienie.Include(z => z.Klient).Include(z => z.Produkt);
            return View(await hypta_ProjektContext.ToListAsync());
        }

        // GET: Zamowienia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Klient)
                .Include(z => z.Produkt)
                .FirstOrDefaultAsync(m => m.ZamowienieID == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienia/Create
        public IActionResult Create()
        {
            ViewData["KlientID"] = new SelectList(_context.Set<Klient>(), "KlientID", "KlientID");
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa");
            return View();
        }

        // POST: Zamowienia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZamowienieID,DataZamowienia,StatusZamowienia,ProduktID,KlientID")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientID"] = new SelectList(_context.Set<Klient>(), "KlientID", "KlientID", zamowienie.KlientID);
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa", zamowienie.ProduktID);
            return View(zamowienie);
        }

        // GET: Zamowienia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            ViewData["KlientID"] = new SelectList(_context.Set<Klient>(), "KlientID", "KlientID", zamowienie.KlientID);
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa", zamowienie.ProduktID);
            return View(zamowienie);
        }

        // POST: Zamowienia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZamowienieID,DataZamowienia,StatusZamowienia,ProduktID,KlientID")] Zamowienie zamowienie)
        {
            if (id != zamowienie.ZamowienieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.ZamowienieID))
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
            ViewData["KlientID"] = new SelectList(_context.Set<Klient>(), "KlientID", "KlientID", zamowienie.KlientID);
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa", zamowienie.ProduktID);
            return View(zamowienie);
        }

        // GET: Zamowienia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Klient)
                .Include(z => z.Produkt)
                .FirstOrDefaultAsync(m => m.ZamowienieID == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie != null)
            {
                _context.Zamowienie.Remove(zamowienie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienie.Any(e => e.ZamowienieID == id);
        }
    }
}
