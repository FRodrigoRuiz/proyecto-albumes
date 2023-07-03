using Albumes.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Albumes.Services;

public interface IRolesService
{
    List<IdentityRole> GetAll();
    
    List<IdentityRole> GetAll(string namefilter);
    void create(RoleCreateViewModel obj);
    Task<RoleCreateViewModel?> GetById(string id);
    void Delete(RoleCreateViewModel obj);
}