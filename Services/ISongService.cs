using Albumes.ViewModels;
using Albumes.Models;
namespace Albumes.Services;

public interface ISongService
{
    SongSearchViewModel GetAll();
    void Update(Song obj);
    void Delete(Song obj);
    Song? GetById(int id);
    SongSearchViewModel GetAll(string nameFilter);
}