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
using Albumes.Services;

namespace Albumes.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: Artist
        public IActionResult Index(string nameFilter)
        {
            ArtistViewModel artists;
            
            if (!string.IsNullOrEmpty(nameFilter))
            {
                artists = _artistService.GetAll(nameFilter);
            }else{
                artists = _artistService.GetAll();
            }

            return artists != null ? 
                    View(artists) :
                    Problem("Entity set 'AlbumContext.Artist'  is null.");
        }

        public IActionResult Stock(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetArtistWithStockById(id.Value);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artist/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetById(id.Value);

            if (artist == null)
            {
                return NotFound();
            }

            var viewModel = new ArtistDetailViewModel();
            viewModel.Name = artist.Name;
            viewModel.Birthdate = artist.Birthdate;
            viewModel.Genre = artist.Genre;

            return View(viewModel);
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
        public IActionResult Create([Bind("Id,Name,Birthdate,Genre")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistService.Update(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artist/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetById(id.Value);
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
        public IActionResult Edit(int id, [Bind("Id,Name,Birthdate,Genre")] Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _artistService.Update(artist);
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetById(id.Value);
            
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
        public IActionResult DeleteConfirmed(int id)
        {
            var artistViewModel = _artistService.GetArtistWithStockById(id);
            if (artistViewModel.Artist != null)
            {
                _artistService.Delete(artistViewModel.Artist);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _artistService.GetById(id) != null;
        }
    }
}
