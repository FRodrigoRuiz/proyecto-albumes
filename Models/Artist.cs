namespace Albumes.Models;

public class Artist {
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual List<Album> Albums { get; set; }
}