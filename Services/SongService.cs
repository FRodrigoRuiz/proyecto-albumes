using Albumes.Data;
using Albumes.Models;
using Albumes.ViewModels;

namespace Albumes.Services;

public class SongService : ISongService
{
    private readonly AlbumContext _context;

    public SongService(AlbumContext albumContext){
        _context = albumContext;
    }

    public void Delete(Song obj)
    {
        _context.Remove(obj);
        _context.SaveChangesAsync();
    }

    public SongSearchViewModel GetAll()
    {
        var query = GetQuery();
        SongSearchViewModel songViewModel = new SongSearchViewModel();
        songViewModel.Songs = query.ToList();
        return songViewModel;
    }

    public SongSearchViewModel GetAll(string nameFilter)
    {
        var query = GetQuery();
        query = query.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower()) || x.AlbumName.ToLower().Contains(nameFilter.ToLower()));
        
        SongSearchViewModel songViewModel = new SongSearchViewModel();
        songViewModel.Songs = query.ToList();
        return songViewModel;
    }

    public Song? GetById(int id)
    {
        var song = _context.Song
                .FirstOrDefault(m => m.Id == id);
        return song;
    }

    public void Update(Song obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Song> GetQuery()
    {
        return from song in _context.Song select song;
    }
}