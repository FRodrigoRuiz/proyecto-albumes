using Albumes.Models;

namespace Albumes.ViewModels;

public class ArtistViewModel {
    public List<Album> Albums { get; set; } = new List<Album>();
    public List<Artist>? Artists { get; set; } = new List<Artist>();
    public string NameFilter { get; set; }
}