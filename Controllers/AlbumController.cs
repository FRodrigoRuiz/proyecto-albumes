using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albumes.Data;
using Albumes.Models;
using Albumes.ViewModels;
using Albumes.Services;
using Microsoft.AspNetCore.Authorization;

namespace Albumes.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;

        public AlbumController(IAlbumService albumService, ISongService songService)
        {
            _albumService = albumService;
            _songService = songService;
        }

        // GET: Album
        public IActionResult Index(string? nameFilter)
        {
            AlbumViewModel albums;

            if(!string.IsNullOrEmpty(nameFilter)){
                albums = _albumService.GetAll(nameFilter);
            }else{
                albums = _albumService.GetAll();
            }

            return albums != null ? 
                        View(albums) :
                        Problem("Entity set 'AlbumContext.Album'  is null.");
        }

        // GET: Album/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumService.GetById(id.Value);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            AlbumCreateViewModel model = new AlbumCreateViewModel();
            var songs = _songService.GetAll();
            model.Songs = songs.Songs;
            return View(model);
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AlbumCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _albumService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model.Album);
        }

        // GET: Album/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album =  _albumService.GetById(id.Value);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlbumCreateViewModel model)
        {
            if (id != model.Album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _albumService.Update(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(model.Album.Id))
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
            return View(model.Album);
        }

        // GET: Album/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _albumService.GetById(id.Value);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var album = _albumService.GetById(id);
            if (album != null)
            {
                _albumService.Delete(album);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
          return _albumService.GetById(id) != null;
        }
    }
}
