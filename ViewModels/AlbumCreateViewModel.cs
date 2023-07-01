using System.ComponentModel.DataAnnotations;
using Albumes.Utils;
using Albumes.Models;

namespace Albumes.ViewModels;

public class AlbumCreateViewModel
{
    public Album Album { get; set; }
    public List<int>? SelectedSongs {get; set;} = new List<int>();
    public List<Song>? Songs {get; set;} 
}