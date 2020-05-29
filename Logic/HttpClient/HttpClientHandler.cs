using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebExchanger.Logic.HttpClient.HttpModel;
using WebExchanger.Service;

namespace WebExchanger.Logic.HttpClient
{
    public class HttpClientHandler
    {

        public static double GetExchangeRateAsync(string fromCurrency,string toCurrency)
        {
            if (CheckInternetConection.IsConnectedToInternet())
            {
                WebClient client = new WebClient();

                string content = client.DownloadString($"{Config.ApiString.Replace("{From}",fromCurrency).Replace("{To}",toCurrency)}");

                if (content != "")
                {

                    ExchangeRateModel exchangeRate = JsonConvert.DeserializeObject<ExchangeRateModel>(content);

                    foreach (double item in exchangeRate.rates)
                    {
                        return item;
                    }

                }
                return 0;
            }
            else
            {
                return 0;
            }

        }


    }
}
