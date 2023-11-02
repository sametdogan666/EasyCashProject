using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.ViewComponents.Customer;

public class _CustomerLayoutSidebarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}