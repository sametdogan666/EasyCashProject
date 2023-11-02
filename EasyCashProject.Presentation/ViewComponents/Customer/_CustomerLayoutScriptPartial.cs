using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.ViewComponents.Customer;

public class _CustomerLayoutScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}