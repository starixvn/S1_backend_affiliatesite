using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Domain.Shared
{
    public class ExchangeRate
    {
        public decimal Rate { get; set; }
        public string CurrencyName { get; private set; }
        public string TargetCurrencyName { get; private set; }
    }
}
