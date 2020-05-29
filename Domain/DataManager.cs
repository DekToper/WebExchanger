using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExchanger.Domain.Entities;
using WebExchanger.Domain.Repositories.Abstract;

namespace WebExchanger.Domain
{
    public class DataManager
    {
        public IExchangeHistoryRepository ExchangeHistory { get; set; }

        public DataManager(IExchangeHistoryRepository exchangeHistoryRepository)
        {
            ExchangeHistory = exchangeHistoryRepository;
        }
    }
}
