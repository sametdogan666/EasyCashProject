using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.ViewComponents.Customer;

public class _CustomerLayoutFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}