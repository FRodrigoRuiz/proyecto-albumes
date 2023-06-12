using System.ComponentModel.DataAnnotations;
using Albumes.Models;

namespace Albumes.ViewModels;

public class StockViewModel {
    public int Id { get; set; }
    public int? AlbumId { get; set; }
    public int? ArtistId { get; set; }
    public virtual Album? Album { get; set; } 
    public virtual Artist? Artist { get; set; } 
    [Display(Name="Cantidad")]
    public int Quantity { get; set; }
}