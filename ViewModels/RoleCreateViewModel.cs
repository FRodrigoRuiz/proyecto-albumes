using System.ComponentModel.DataAnnotations;

namespace Albumes.ViewModels;

public class RoleCreateViewModel
{
    [Display(Name="Rol")]
    public string RoleName { get; set; }
}