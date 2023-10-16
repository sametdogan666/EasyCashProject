using EasyCashProject.Entities.Concrete;
using EasyCashProject.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

public class ConfirmEmailController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public ConfirmEmailController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
	public IActionResult Index()
    {
        var value = TempData["Email"];
        ViewBag.Email = value;

        return View();
	}

    [HttpPost]
    public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
    {
        
        var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Email);
        if (user.ConfirmCode == confirmMailViewModel.ConfirmCode)
        {
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Login");
        }

        return View();
    }
}