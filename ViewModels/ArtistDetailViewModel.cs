using System.ComponentModel.DataAnnotations;
using Albumes.Models;
using Albumes.Utils;

namespace Albumes.ViewModels;

public class ArtistDetailViewModel{
    public int Id { get; set; }
    [Display(Name="Nombre")]
    public string Name { get; set; }
    [Display(Name="Año de nacimiento")]
    public int Birthdate { get; set; }
    [Display(Name="Genero")]
    public Genre Genre { get; set; }
}
