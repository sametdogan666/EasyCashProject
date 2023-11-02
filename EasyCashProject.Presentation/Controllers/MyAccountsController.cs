using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

public class MyAccountsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}