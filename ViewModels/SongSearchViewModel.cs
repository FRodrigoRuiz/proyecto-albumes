using Albumes.Models;

namespace Albumes.ViewModels;

public class SongSearchViewModel
{
    public List<Song> Songs {get; set;} = new List<Song>();

    public string? NameFilter { get; set; }
}