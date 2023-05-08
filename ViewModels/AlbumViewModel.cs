using Albumes.Models;

namespace Albumes.ViewModels;

public class AlbumViewModel {
    public List<Album> Albums { get; set; } = new List<Album>();
    public string? Filter { get; set; }
    public int ArtistId { get; set; }
}