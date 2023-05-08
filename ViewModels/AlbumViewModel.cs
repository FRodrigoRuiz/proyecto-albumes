using Albumes.Models;

namespace Albumes.ViewModels;

public class AlbumViewModel {
    public List<Album> Albums { get; set; } = new List<Album>();
    public string? NameFilter { get; set; }
    public Album Album { get; set; } = new Album();
}