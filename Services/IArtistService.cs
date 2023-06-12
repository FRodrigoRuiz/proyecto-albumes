using Albumes.Models;
using Albumes.ViewModels;

namespace Albumes.Services;

public interface IArtistService
{
    ArtistViewModel GetAll();
    ArtistViewModel GetAll(string nameFilter);
    void Update(Artist obj);
    void Delete(Artist obj);
    Artist? GetById(int id);
    ArtistViewModel? GetArtistWithStockById(int id);
}