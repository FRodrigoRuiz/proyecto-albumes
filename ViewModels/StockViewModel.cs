using Albumes.Models;

namespace Albumes.ViewModels;

public class StockViewModel {
    public int ArtistId { get; set; }
    public List<Album> Albums { get; set; }
    public Stock Stock { get; set; } = new Stock();
}