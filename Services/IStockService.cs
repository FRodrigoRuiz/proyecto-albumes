using Albumes.Models;

namespace Albumes.Services;

public interface IStockService
{
    List<Stock> GetAll();
    List<Stock> GetAll(string nameFiler);
    void Update(Stock obj);
    void Delete(Stock obj);
    Stock? GetById(int id);
    Stock? GetStockByArtistIdAndAlbumId(int artistId, int albumId);
}