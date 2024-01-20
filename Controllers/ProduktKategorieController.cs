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
    public class ProduktKategorieController : Controller
    {
        private readonly Hypta_ProjektContext _context;

        public ProduktKategorieController(Hypta_ProjektContext context)
        {
            _context = context;
        }

        // GET: ProduktKategorie
        public async Task<IActionResult> Index()
        {
            var hypta_ProjektContext = _context.ProduktKategoria.Include(p => p.Kategoria).Include(p => p.Produkt);
            return View(await hypta_ProjektContext.ToListAsync());
        }

        // GET: ProduktKategorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktKategoria = await _context.ProduktKategoria
                .Include(p => p.Kategoria)
                .Include(p => p.Produkt)
                .FirstOrDefaultAsync(m => m.ProduktKategoriaID == id);
            if (produktKategoria == null)
            {
                return NotFound();
            }

            return View(produktKategoria);
        }

        // GET: ProduktKategorie/Create
        public IActionResult Create()
        {
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa");
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa");
            return View();
        }

        // POST: ProduktKategorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduktKategoriaID,KategoriaID,ProduktID")] ProduktKategoria produktKategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produktKategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa", produktKategoria.KategoriaID);
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa", produktKategoria.ProduktID);
            return View(produktKategoria);
        }

        // GET: ProduktKategorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktKategoria = await _context.ProduktKategoria.FindAsync(id);
            if (produktKategoria == null)
            {
                return NotFound();
            }
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa", produktKategoria.KategoriaID);
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa", produktKategoria.ProduktID);
            return View(produktKategoria);
        }

        // POST: ProduktKategorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduktKategoriaID,KategoriaID,ProduktID")] ProduktKategoria produktKategoria)
        {
            if (id != produktKategoria.ProduktKategoriaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produktKategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktKategoriaExists(produktKategoria.ProduktKategoriaID))
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
            ViewData["KategoriaID"] = new SelectList(_context.Kategoria, "KategoriaID", "Nazwa", produktKategoria.KategoriaID);
            ViewData["ProduktID"] = new SelectList(_context.Produkt, "ProduktID", "Nazwa", produktKategoria.ProduktID);
            return View(produktKategoria);
        }

        // GET: ProduktKategorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktKategoria = await _context.ProduktKategoria
                .Include(p => p.Kategoria)
                .Include(p => p.Produkt)
                .FirstOrDefaultAsync(m => m.ProduktKategoriaID == id);
            if (produktKategoria == null)
            {
                return NotFound();
            }

            return View(produktKategoria);
        }

        // POST: ProduktKategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produktKategoria = await _context.ProduktKategoria.FindAsync(id);
            if (produktKategoria != null)
            {
                _context.ProduktKategoria.Remove(produktKategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktKategoriaExists(int id)
        {
            return _context.ProduktKategoria.Any(e => e.ProduktKategoriaID == id);
        }
    }
}
