using Albumes.Models;

namespace Albumes.ViewModels;

public class ArtistViewModel {
    public List<Album> Albums { get; set; } = new List<Album>();
    public List<Artist>? Artists { get; set; } = new List<Artist>();
    public string? NameFilter { get; set; }
    public virtual List<Stock>? Stocks { get; set; }
    public Artist Artist { get; set; } = new();
    public int quantityInStock { get; set; }
    public int Id { get; set; }
    public int Quantity{ get; set; }
    public double total { get; set; }
}