using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albumes.Data;
using Albumes.Models;
using Albumes.Utils;
using Albumes.ViewModels;

namespace Albumes.Controllers
{
    public class ArtistController : Controller
    {
        private readonly AlbumContext _context;

        public ArtistController(AlbumContext context)
        {
            _context = context;
        }

        // GET: Artist
        public async Task<IActionResult> Index(string nameFilter)
        {
            var query = from artist in _context.Artist select artist;
            
            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower()));
            }

            var viewModel = new ArtistViewModel();
            viewModel.Artists = await query.ToListAsync();

              return _context.Artist != null ? 
                          View(viewModel) :
                          Problem("Entity set 'AlbumContext.Artist'  is null.");
        }

        public async Task<IActionResult> Stock(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.Include(x=> x.Stocks).ThenInclude(i => i.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Birthdate,Genre")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Birthdate,Genre")] Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Id))
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
            return View(artist);
        }

        // GET: Artist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }


        /*
        Este es un método que maneja la eliminación de un artista junto con su stock asociado. 
        Primero, se verifica si la tabla de Artist existe. Luego, se utiliza el método Include para 
        cargar los datos de la tabla Stock y Album relacionados con el artista que se va a eliminar. 
        Luego, se utiliza el método RemoveRange para eliminar todo el stock del artista y finalmente 
        se elimina al artista de la tabla Artist.
        */
        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artist == null)
            {
                return Problem("Entity set 'AlbumContext.Artist'  is null.");
            }
            var artist = await _context.Artist.Include(x=> x.Stocks).ThenInclude(i => i.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist != null)
            {
                _context.Stock.RemoveRange(artist.Stocks);
                _context.Artist.Remove(artist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
          return (_context.Artist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
