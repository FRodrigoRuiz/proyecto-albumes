using Albumes.Models;

namespace Albumes.ViewModels;

public class AlbumViewModel {
    public List<Album> Albumes { get; set; }
    public string? Filter { get; set; }
}