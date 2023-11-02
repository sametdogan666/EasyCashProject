using EasyCashProject.Business.Abstract;
using EasyCashProject.DataAccess.Concrete;
using EasyCashProject.DTO.Dtos.CustomerAccountProcessDtos;
using EasyCashProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

public class SendMoneyController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICustomerAccountProcessService _customerAccountProcessService;

    public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
    {
        _userManager = userManager;
        _customerAccountProcessService = customerAccountProcessService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto accountProcessDto)
    {
        var context = new Context();

        var receiverAccountNumberId =
            context.CustomerAccounts.Where(x => x.CustomerAccountNumber == accountProcessDto.ReceiverAccountNumber).Select(y => y.Id).FirstOrDefault();

        var user = await _userManager.FindByNameAsync(User.Identity?.Name);
        accountProcessDto.SenderId = user.Id;
        accountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        accountProcessDto.ProcessType = "Havale";
        accountProcessDto.ReceiverId = receiverAccountNumberId;

        //_customerAccountProcessService.Add();

        return RedirectToAction("Index", "Deneme");
    }
}