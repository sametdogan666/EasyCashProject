using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.ViewComponents.Customer;

public class _CustomerLayoutHeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}