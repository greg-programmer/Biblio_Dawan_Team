using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuteursController : Controller
    {
        private readonly BiblioContext _context;

        public AuteursController(BiblioContext context)
        {
            _context = context;
        }

        // GET: Auteurs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Auteurs.ToListAsync());
        }

        // GET: Auteurs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteur = await _context.Auteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auteur == null)
            {
                return NotFound();
            }

            return View(auteur);
        }

        // GET: Auteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Date_Naissance,Date_Mort,Id")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auteur);
        }

        // GET: Auteurs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteur = await _context.Auteurs.FindAsync(id);
            if (auteur == null)
            {
                return NotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Nom,Prenom,Date_Naissance,Date_Mort,Id")] Auteur auteur)
        {
            if (id != auteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuteurExists(auteur.Id))
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
            return View(auteur);
        }

        // GET: Auteurs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteur = await _context.Auteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auteur == null)
            {
                return NotFound();
            }

            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Auteurs == null)
            {
                return Problem("Entity set 'WebApplication1Context.Auteurs'  is null.");
            }
            var auteur = await _context.Auteurs.FindAsync(id);
            if (auteur != null)
            {
                _context.Auteurs.Remove(auteur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuteurExists(long id)
        {
          return _context.Auteurs.Any(e => e.Id == id);
        }
    }
}
