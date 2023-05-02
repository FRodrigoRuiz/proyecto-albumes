using Albumes.Utils;

namespace Albumes.Models;

public class Album {
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public int Year { get; set; }

    public string Story { get; set; }

    public byte[] Cover { get; set; }

    public Genre Genre { get; set; }
}