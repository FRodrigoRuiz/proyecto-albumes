using Albumes.Models;
using Albumes.ViewModels;

namespace Albumes.Services;

public interface IAlbumService
{
    AlbumViewModel GetAll();
    void Update(AlbumCreateViewModel obj);
    void Delete(Album obj);
    Album? GetById(int id);
    AlbumViewModel GetAll(string nameFilter);
}