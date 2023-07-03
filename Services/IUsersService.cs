using Microsoft.AspNetCore.Identity;
using Albumes.ViewModels;

namespace Albumes.Services;

public interface IUsersService
{
    List<IdentityUser> GetAll();

    List<IdentityUser> GetAll(string usernameFilter);
    void Assign(UserEditViewModel obj);
    void Remove(UserEditViewModel obj);
    Task<UserEditViewModel?> GetById(string id);
}