using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.ViewComponents.Customer;

public class _CustomerLayoutNavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}