using System.ComponentModel.DataAnnotations;
using Albumes.Utils;

namespace Albumes.Models;

public class Album {
    public int Id { get; set; }

    [Display(Name="Titulo del album")]
    public string Title { get; set; }
    [Display(Name="Año de lanzamiento")]
    public int Year { get; set; }
    [Display(Name="Informacion del album")]
    public string Story { get; set; }
    [Display(Name="Genero musical")]
    public Genre Genre { get; set; }
    [Display(Name="Precio")]
    public int Price { get; set; }
}