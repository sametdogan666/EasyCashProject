using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.Presentation.Controllers;

public class ExchangeController : Controller
{

    public async Task<IActionResult> Index()
    {
        #region UsdToTry

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
            Headers =
            {
                { "X-RapidAPI-Key", "64530ed815msh7e6314fe21756e6p1bfc48jsn719a348b9c16" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            ViewBag.UsdToTry = body;
        }

        #endregion

        #region EurToTry

        var client2 = new HttpClient();
        var request2 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
            Headers =
            {
                { "X-RapidAPI-Key", "64530ed815msh7e6314fe21756e6p1bfc48jsn719a348b9c16" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
            },
        };
        using (var response2 = await client2.SendAsync(request2))
        {
            response2.EnsureSuccessStatusCode();
            var body2 = await response2.Content.ReadAsStringAsync();
            ViewBag.EurToTry = body2;
        }

        #endregion

        #region GbpToTry

        var client3 = new HttpClient();
        var request3 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
            Headers =
            {
                { "X-RapidAPI-Key", "64530ed815msh7e6314fe21756e6p1bfc48jsn719a348b9c16" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
            },
        };
        using (var response3 = await client3.SendAsync(request3))
        {
            response3.EnsureSuccessStatusCode();
            var body3 = await response3.Content.ReadAsStringAsync();
            ViewBag.GbpToTry = body3;
        }

        #endregion

        return View();
    }
}