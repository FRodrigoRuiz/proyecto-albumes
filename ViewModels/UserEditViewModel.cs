using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Albumes.ViewModels;

public class UserEditViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    [Display(Name="Rol")]
    public string Role { get; set; }
    public SelectList Roles { get; set; }
}