using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

public class MyProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}