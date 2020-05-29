using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExchanger.Domain.Entities;
using WebExchanger.Domain.Repositories.Abstract;

namespace WebExchanger.Domain.Repositories.EntityFramework
{
    public class EFExchangeHistoryRepository : IExchangeHistoryRepository
    {
        private readonly AppDbContext context;
        
        public EFExchangeHistoryRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }

        public IQueryable<ExchangeHistory> GetExchangeHistory()
        {
            return context.ExchangeHistory;
        }

        public ExchangeHistory GetExchangeHistoryByDate(DateTime Date)
        {
            return context.ExchangeHistory.FirstOrDefault(x => x.Date == Date);
        }

        public ExchangeHistory GetExchangeHistoryByFromAmount(double FromAmount)
        {
            return context.ExchangeHistory.FirstOrDefault(x => x.FromAmount == FromAmount);
        }

        public ExchangeHistory GetExchangeHistoryByFromCurrency(string FromCurrency)
        {
            return context.ExchangeHistory.FirstOrDefault(x => x.FromCurrency == FromCurrency);
        }

        public ExchangeHistory GetExchangeHistoryById(int Id)
        {
            return context.ExchangeHistory.FirstOrDefault(x => x.Id == Id);
        }

        public ExchangeHistory GetExchangeHistoryByToAmount(double ToAmount)
        {
            return context.ExchangeHistory.FirstOrDefault(x => x.ToAmount == ToAmount);
        }

        public ExchangeHistory GetExchangeHistoryByToCurrency(string ToCurrency)
        {
            return context.ExchangeHistory.FirstOrDefault(x => x.ToCurrency == ToCurrency);
        }

        public void SaveExchangeHistory(ExchangeHistory exchangeHistory)
        {
            context.ExchangeHistory.Add(exchangeHistory);
            context.SaveChanges();
        }
    }
}
