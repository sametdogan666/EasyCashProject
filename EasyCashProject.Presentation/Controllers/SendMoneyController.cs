﻿using EasyCashProject.Business.Abstract;
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
    public IActionResult Index(string mycurrency)
    {
        ViewBag.currency = mycurrency;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto accountProcessDto)
    {
        var context = new Context();
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);
        var receiverAccountNumberId =
            context.CustomerAccounts.Where(x => x.CustomerAccountNumber == accountProcessDto.ReceiverAccountNumber).Select(y => y.Id).FirstOrDefault();
        var senderAccountNumberId = context.CustomerAccounts.Where(x=>x.AppUserId == user.Id).Where(y=>y.CustomerAccountCurrency == "Türk Lirası").Select(z => z.Id).FirstOrDefault();

        var values = new CustomerAccountProcess();

        values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        values.SenderId = senderAccountNumberId;
        values.ReceiverId = receiverAccountNumberId;
        values.ProcessType = "Havale";
        values.Amount = accountProcessDto.Amount;
        values.Description = accountProcessDto.Description;

        _customerAccountProcessService.Add(values);

        return RedirectToAction("Index", "Deneme");
    }

}