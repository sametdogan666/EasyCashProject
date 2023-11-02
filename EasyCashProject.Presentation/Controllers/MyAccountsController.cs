using EasyCashProject.DTO.Dtos.AppUserDtos;
using EasyCashProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

[Authorize]
public class MyAccountsController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public MyAccountsController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        AppUserEditDto appUserEditDto = new AppUserEditDto();
        appUserEditDto.FirstName = values.FirstName;
        appUserEditDto.LastName = values.LastName;
        appUserEditDto.Email = values.Email;
        appUserEditDto.City = values.City;
        appUserEditDto.PhoneNumber = values.PhoneNumber;
        appUserEditDto.District = values.District;
        appUserEditDto.ImageUrl = values.ImageUrl;

        return View(appUserEditDto);
    }
}