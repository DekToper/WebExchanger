using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebExchanger.Models
{
    public class ExchangeViewModel
    {
        [Required]
        [Display(Name = "FromAmount")]
        public double FromAmount { get; set; }

        [Required]
        [Display(Name = "FromCurrency")]
        public string FromCurrency { get; set; }

        [Required]
        [Display(Name = "ToCurrency")]
        public string ToCurrency { get; set; }
    }
}
