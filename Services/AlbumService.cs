using Albumes.Data;
using Albumes.Models;
using Albumes.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Albumes.Services;

public class AlbumService : IAlbumService
{
    private readonly AlbumContext _context;
    public AlbumService(AlbumContext context){
        _context = context;
    }
    public void Delete(Album obj)
    {
        _context.Remove(obj);
        _context.SaveChangesAsync();
    }

    public AlbumViewModel GetAll()
    {
        var query = GetQuery();
        AlbumViewModel albums = new AlbumViewModel();
        albums.Albums = query.ToList();
        return albums;
    }

    public AlbumViewModel GetAll(string nameFilter)
    {
        var query = GetQuery();
        query = query.Where(x => x.Title.ToLower().Contains(nameFilter.ToLower()) || x.Year.ToString().Contains(nameFilter));
        
        AlbumViewModel albums = new AlbumViewModel();
        albums.Albums = query.ToList();
        return albums;
    }

    public Album? GetById(int id)
    {
        var album = _context.Album.FirstOrDefault(m => m.Id == id);
        return album;      
    }

    public void Update(Album obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
    private IQueryable<Album> GetQuery()
    {
        return from album in _context.Album select album;
    }
}