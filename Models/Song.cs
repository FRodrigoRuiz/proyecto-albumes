using System.ComponentModel.DataAnnotations;

namespace Albumes.Models;

public class Song {
    public int Id { get; set; }
    [Display(Name="Nombre de las canciones")]
    public string Name { get; set; }

    [Display(Name="Nombre del album")]
    public string AlbumName{get; set;}

    public virtual List<Album>? Albums {get; set;} 

}