using Albumes.Data;
using Albumes.Models;

namespace Albumes.Services;

public class StockService : IStockService
{
    private readonly AlbumContext _context;
    
    public StockService(AlbumContext context){
        _context = context;
    }
    public void Delete(Stock obj)
    {
        _context.Stock.Remove(obj);
        _context.SaveChanges();
    }

    public List<Stock> GetAll()
    {
        List<Stock> stocks = new List<Stock>();
        stocks = _context.Stock.ToList();
        return stocks;
    }

    public List<Stock> GetAll(string nameFiler)
    {
        throw new NotImplementedException();
    }

    public Stock? GetById(int id)
    {
        return _context.Stock.FirstOrDefault(m => m.Id == id);
    }

    public Stock? GetStockByArtistIdAndAlbumId(int artistId, int albumId)
    {
        var stock = _context.Stock.Where(i => i.ArtistId == artistId && i.AlbumId == albumId).FirstOrDefault();
        return stock;
    }

    public void Update(Stock obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}
