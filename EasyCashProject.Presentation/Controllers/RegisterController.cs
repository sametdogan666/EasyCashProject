using EasyCashProject.DTO.Dtos.AppUserDtos;
using EasyCashProject.Entities.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashProject.Presentation.Controllers;

public class RegisterController : Controller
{
	private readonly UserManager<AppUser> _userManager;

	public RegisterController(UserManager<AppUser> userManager)
	{
		_userManager = userManager;
	}

	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
	{
		if (ModelState.IsValid)
		{
			Random random = new Random();
			string code = random.Next(100000, 1000000).ToString();

			AppUser appUser = new AppUser()
			{
				FirstName = appUserRegisterDto.FirstName,
				LastName = appUserRegisterDto.LastName,
				Email = appUserRegisterDto.Email,
				UserName = appUserRegisterDto.UserName,
				ConfirmCode = code
			};

			var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

			if (result.Succeeded)
			{
				MimeMessage mimeMessage = new MimeMessage();
				MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "canimkendiminfo@gmail.com");
				MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

				mimeMessage.From.Add(mailboxAddressFrom);
				mimeMessage.To.Add(mailboxAddressTo);

				var bodyBuilder = new BodyBuilder();
				bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
				mimeMessage.Body = bodyBuilder.ToMessageBody();
				mimeMessage.Subject = "Easy Cash Onay Kodu";

				SmtpClient smtpClient = new SmtpClient();
				smtpClient.Connect("smtp.gmail.com", 587, false);
				smtpClient.Authenticate("canimkendiminfo@gmail.com", "idwhiwkpxpivnenu");
				smtpClient.Send(mimeMessage);
				smtpClient.Disconnect(true);

                TempData["Email"] = appUserRegisterDto.Email;

				return RedirectToAction("Index", "ConfirmEmail");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
		}

		return View();
	}
}