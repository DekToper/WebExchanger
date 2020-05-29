using Microsoft.AspNetCore.Mvc;
using System;
using WebExchanger.Domain;
using WebExchanger.Domain.Entities;
using WebExchanger.Logic.HttpClient;
using WebExchanger.Models;

namespace WebExchanger.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataManager dataManager;

        public HomeController(DataManager data)
        {
            dataManager = data;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Result = 0;
            ViewBag.Rate = "";
            ViewBag.FromAmount = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(double FromAmount, string FromCurrency, string ToCurrency)
        {
            if (FromCurrency == ToCurrency)
            {
                ViewBag.Result = 0;
                ViewBag.Rate = "";
                ViewBag.FromAmount = FromAmount;
                ViewBag.Error = "The currency you want to exchange is the same as the currency you want to receive.";
            }
            else
            {
                ViewBag.FromAmount = FromAmount;
                double rate = HttpClientHandler.GetExchangeRateAsync(FromCurrency, ToCurrency);
                ViewBag.Result = FromAmount*rate;
                ViewBag.Rate = $"•1 {FromCurrency} = {rate} {ToCurrency}";

                ExchangeHistory exchangeHistory = new ExchangeHistory();
                exchangeHistory.Date = DateTime.UtcNow;
                exchangeHistory.FromAmount = FromAmount;
                exchangeHistory.FromCurrency = FromCurrency;
                exchangeHistory.ToAmount = ViewBag.Result;
                exchangeHistory.ToCurrency = ToCurrency;

                dataManager.ExchangeHistory.SaveExchangeHistory(exchangeHistory);
            }
            return View();
        }
    }
}
