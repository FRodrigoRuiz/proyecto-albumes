using Albumes.Models;

namespace Albumes.ViewModels;

public class ArtistFormViewModel {
    public int Id { get; set; }

    public string Name { get; set; }
    
    public virtual List<Album> Albums { get; set; }
}