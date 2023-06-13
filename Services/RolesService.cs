using Albumes.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Albumes.Services;

public class RolesService : IRolesService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesService(RoleManager<IdentityRole> roleManager){
        _roleManager = roleManager;
    }

    public void create(RoleCreateViewModel obj)
    {
        var role = new IdentityRole(obj.RoleName);
        _roleManager.CreateAsync(role);
    }

    public List<IdentityRole> GetAll()
    {
        var roles = _roleManager.Roles.ToList();
        return roles;
    }
    public List<IdentityRole> GetAll(string namefilter)
    {
        var roles = _roleManager.Roles.Where(x => x.Name.ToLower().Contains(namefilter.ToLower())).ToList();
        return roles;
    }
}