using Albumes.Data;
using Albumes.Models;
using Albumes.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Albumes.Services;

public class ArtistService : IArtistService
{
    private readonly AlbumContext _context;
    public ArtistService(AlbumContext albumContext){
        _context = albumContext;
    }
    public void Delete(Artist obj)
    {
        if(obj.Stocks != null){
            _context.Stock.RemoveRange(obj.Stocks);
        }        
        _context.Artist.Remove(obj);
    }

    public ArtistViewModel GetAll()
    {
        var query = GetQuery();
        ArtistViewModel artists = new ArtistViewModel();
        artists.Artists = query.ToList();

        return artists;
    }

    public ArtistViewModel GetAll(string nameFilter)
    {
        var query = GetQuery();
        query = query.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower()) || x.Birthdate.ToString().Contains(nameFilter));

        ArtistViewModel artists = new ArtistViewModel();
        artists.Artists = query.ToList();

        return artists;
    }

    public ArtistViewModel? GetArtistWithStockById(int id)
    {
        int quantityInStock = 0;
        double total = 0;
        ArtistViewModel artistViewModel = new ArtistViewModel();
        var artist = _context.Artist.Include(x=> x.Stocks).ThenInclude(i => i.Album)
                .FirstOrDefault(m => m.Id == id);

        artistViewModel.Artist = artist;
        if(artist.Stocks != null){
            foreach(Stock i in artist.Stocks){
                quantityInStock += i.Quantity;
                total += i.Album.Price * i.Quantity;
            }
        }
        artistViewModel.quantityInStock = quantityInStock;
        artistViewModel.total = total;

        return artistViewModel;
    }

    public Artist? GetById(int id)
    {
        var artist = _context.Artist.FirstOrDefault(m => m.Id == id);
        return artist;
    }

    public void Update(Artist obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Artist> GetQuery()
    {
        return from artist in _context.Artist select artist;
    }
}