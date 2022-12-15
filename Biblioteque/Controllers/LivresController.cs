using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteque.Models;
using Biblioteque.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace Biblioteque.Controllers
{
    public class LivresController : Controller
    {
        private readonly BiblioContext _context;
        private readonly IHostEnvironment _environment;

        public LivresController(BiblioContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        

        // GET: Livres1
        public async Task<IActionResult> Index()
        {
              return View(await _context.Livres.ToListAsync());
        }

        // GET: Livres1/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Livres == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // GET: Livres1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livres1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titre,Date_Parution,Synopsis,Id,Image,CheminImage")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                // string wwwRootPath = _environment.ContentRootPath;
                string wwwRootPath = Environment.CurrentDirectory;
                string fileName = Path.GetFileNameWithoutExtension(path: livre.Image.FileName);
                string extension = Path.GetExtension(livre.Image.FileName);
                livre.CheminImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath, "wwwroot", "Upload", fileName);
                
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await livre.Image.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(livre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livre);

            
        }

        // GET: Livres1/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Livres == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }
            return View(livre);
        }

        // POST: Livres1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Titre,Date_Parution,Synopsis,Id,Image,CheminImage")] Livre livre)
        {
            if (id != livre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                string wwwRootPath = Environment.CurrentDirectory;
                string fileName = Path.GetFileNameWithoutExtension(path: livre.Image.FileName);
                string extension = Path.GetExtension(livre.Image.FileName);
                livre.CheminImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath, "wwwroot", "Upload", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await livre.Image.CopyToAsync(fileStream);
                }


                try
                {
                    _context.Update(livre);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreExists(livre.Id))
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
            return View(livre);
        }

        // GET: Livres1/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Livres == null)
            {
                return NotFound();
            }

            var livre = await _context.Livres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // POST: Livres1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Livres == null)
            {
                return Problem("Entity set 'BiblioContext.Livres'  is null.");
            }
            var livre = await _context.Livres.FindAsync(id);
            if (livre != null & livre.CheminImage != null)
            {
                string wwwRootPath = Environment.CurrentDirectory;
                string path = Path.Combine(wwwRootPath,"wwwroot","Upload", livre.CheminImage);

                System.IO.File.Delete(path);    
            }
            _context.Livres.Remove(livre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivreExists(long id)
        {
          return _context.Livres.Any(e => e.Id == id);
        }

        [Route("Livres/Search")]
        public async Task<IActionResult> Search(string id)
        {
            if (_context.Livres == null)
            {
                return Problem("Entity set 'BibliContext.livres'  is null.");
            }

            var livres = from l in _context.Livres
                         select l;

            if (!String.IsNullOrEmpty(id))
            {
                livres = livres.Where(l => l.Titre.Contains(id));
            }

            return View(await livres.ToListAsync());
        }
    }
}
