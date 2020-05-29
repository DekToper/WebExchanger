using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebExchanger.Domain.Entities
{
    public class ExchangeHistory
    {
        public int Id { get; set; }

        [Required]
        public string FromCurrency { get; set; }

        public double FromAmount { get; set; }

        [Required]
        public string ToCurrency { get; set; }

        public double ToAmount { get; set; }

        public DateTime Date { get; set; }
    }
}
