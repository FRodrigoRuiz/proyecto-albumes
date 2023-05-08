using Albumes.Models;
using Albumes.Utils;

namespace Albumes.ViewModels;

public class AlbumFormViewModel {
    public int Id { get; set; }

    public string Title { get; set; }

    public int Year { get; set; }

    public string Story { get; set; }

    public byte[] Cover { get; set; }

    public Genre Genre { get; set; }

    public int ArtistId { get; set; }
    public virtual Artist Artist { get; set; }
}