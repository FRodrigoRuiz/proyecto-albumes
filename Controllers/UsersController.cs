using Albumes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Albumes.Services;

namespace Albumes.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUsersService _usersService;

    public UsersController(
        ILogger<HomeController> logger,
        IUsersService usersService)
    {
        _logger = logger;
        _usersService = usersService;
    }

    public IActionResult Index(string? usernameFilter)
    {
        UserSearchViewModel userSearchViewModel;
        List<IdentityUser> usersList;

        if(!string.IsNullOrEmpty(usernameFilter)){
                usersList = _usersService.GetAll(usernameFilter);
            }else{
                usersList = _usersService.GetAll();
        }
        userSearchViewModel = new UserSearchViewModel();
        userSearchViewModel.Users = usersList;       
        return View(userSearchViewModel);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var userViewModel = await _usersService.GetById(id);
        return View(userViewModel);
    }

    [HttpPost]
    public IActionResult Edit(UserEditViewModel model)
    {
        _usersService.Update(model);
        return RedirectToAction("Index");
    }
}