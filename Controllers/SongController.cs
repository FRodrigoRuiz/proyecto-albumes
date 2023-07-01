using Albumes.Models;
using Albumes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Albumes.ViewModels;

namespace Albumes.Controllers;
public class SongController : Controller
{
    private readonly ISongService _songService;

    public SongController(ISongService songService){
        _songService = songService;
    }

    public IActionResult Index(string? nameFilter)
    {
        SongSearchViewModel songSearchViewModel;
        if(!string.IsNullOrEmpty(nameFilter)){
            songSearchViewModel = _songService.GetAll(nameFilter);
        }else{
            songSearchViewModel = _songService.GetAll();
        }
        return View(songSearchViewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([Bind("Id,Name,AlbumName")]Song model)
    {
        if (ModelState.IsValid)
        {
            _songService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = _songService.GetById(id.Value);
        if (song == null)
        {
            return NotFound();
        }

        return View(song);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var song = _songService.GetById(id);
        if (song != null)
        {
            _songService.Delete(song);
        }
                    
        return RedirectToAction(nameof(Index));
    }
}