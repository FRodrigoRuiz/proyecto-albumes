using System.ComponentModel.DataAnnotations;
using Albumes.Utils;

namespace Albumes.Models;

public class Artist {
    public int Id { get; set; }
    [Display(Name="Nombre")]
    public string Name { get; set; }
    [Display(Name="Año de nacimiento")]
    public int Birthdate { get; set; }
    [Display(Name="Genero musical")]
    public Genre Genre { get; set; }
    public virtual List<Stock>? Stocks { get; set; } 
}