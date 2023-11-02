using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

public class CustomerLayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}