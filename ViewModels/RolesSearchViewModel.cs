using Microsoft.AspNetCore.Identity;

namespace Albumes.ViewModels;

public class RolesSearchViewModel{

    public List<IdentityRole>? Roles { get; set;} = new List<IdentityRole>();

    public string? nameFilter { get; set; }

}