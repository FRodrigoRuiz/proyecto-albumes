using Microsoft.AspNetCore.Identity;
using Albumes.ViewModels;

namespace Albumes.Services;

public interface IUsersService
{
    List<IdentityUser> GetAll();

    List<IdentityUser> GetAll(string usernameFilter);
    void Update(UserEditViewModel obj);
    void Delete(UserEditViewModel obj);
    Task<UserEditViewModel?> GetById(string id);
}