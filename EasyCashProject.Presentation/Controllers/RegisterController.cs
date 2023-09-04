using EasyCashProject.DTO.Dtos.AppUserDtos;
using EasyCashProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

public class RegisterController : Controller
{
	private readonly UserManager<AppUser> _userManager;

	public RegisterController(UserManager<AppUser> userManager)
	{
		_userManager = userManager;
	}

	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
	{
		if (ModelState.IsValid)
		{
			AppUser appUser = new AppUser()
			{
				FirstName = appUserRegisterDto.FirstName,
				LastName = appUserRegisterDto.LastName,
				Email = appUserRegisterDto.Email,
				UserName = appUserRegisterDto.UserName
			};

			var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "ConfirmEmail");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
		}

		return View();
	}
}