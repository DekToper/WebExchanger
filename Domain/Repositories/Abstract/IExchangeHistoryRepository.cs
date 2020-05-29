using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExchanger.Domain.Entities;

namespace WebExchanger.Domain.Repositories.Abstract
{
    public interface IExchangeHistoryRepository
    {
        IQueryable<ExchangeHistory> GetExchangeHistory();
        ExchangeHistory GetExchangeHistoryById(int Id);
        ExchangeHistory GetExchangeHistoryByFromCurrency(string FromCurrency);
        ExchangeHistory GetExchangeHistoryByFromAmount(double FromAmount);
        ExchangeHistory GetExchangeHistoryByToCurrency(string ToCurrency);
        ExchangeHistory GetExchangeHistoryByToAmount(double ToAmount );
        ExchangeHistory GetExchangeHistoryByDate(DateTime Date);
        void SaveExchangeHistory(ExchangeHistory exchangeHistory);
    }
}
