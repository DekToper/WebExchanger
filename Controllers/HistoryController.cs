using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebExchanger.Domain;

namespace WebExchanger.Controllers
{
    public class HistoryController : Controller
    {
        private readonly DataManager dataManager;

        public HistoryController(DataManager data)
        {
            dataManager = data;
        }

        public IActionResult Index()
        {
            ViewBag.Result = null;
            return View(dataManager.ExchangeHistory.GetExchangeHistory());
        }

        [HttpPost]
        public IActionResult Index(string SearchBox, string SearchSelect)
        {
            
            switch (SearchSelect)
            {
                case "Id":
                    {
                        ViewBag.Result = dataManager.ExchangeHistory.GetExchangeHistoryById(Convert.ToInt32(SearchBox));
                        break;
                    }
                case "FromAmount":
                    {
                        ViewBag.Result = dataManager.ExchangeHistory.GetExchangeHistoryByFromAmount(Convert.ToDouble(SearchBox));
                        break;
                    }
                case "FromCurrency":
                    {
                        ViewBag.Result = dataManager.ExchangeHistory.GetExchangeHistoryByFromCurrency(SearchBox);
                        break;
                    }
                case "ToAmount":
                    {
                        ViewBag.Result = dataManager.ExchangeHistory.GetExchangeHistoryByToAmount(Convert.ToDouble(SearchBox));
                        break;
                    }
                case "ToCurrency":
                    {
                        ViewBag.Result = dataManager.ExchangeHistory.GetExchangeHistoryByToCurrency(SearchBox);
                        break;
                    }
                case "Date":
                    {
                        ViewBag.Result = dataManager.ExchangeHistory.GetExchangeHistoryByDate(DateTime.Parse(SearchBox));
                        break;
                    }
                default:
                    {
                        return View(dataManager.ExchangeHistory.GetExchangeHistory());
                    }
            }

            return View(dataManager.ExchangeHistory.GetExchangeHistory());
        }
    }
}