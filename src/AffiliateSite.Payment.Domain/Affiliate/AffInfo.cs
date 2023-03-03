using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Domain.Affiliate
{
    public class AffInfo
    {
        public int AffId { get; private set; }
        public string UserName { get; private set; }
        public int AffCurrency { get; private set; }
        public string AffCurrencyName { get; private set; }
        public string PreferredPayment { get; private set; }
        public int PlayerCustId { get; private set; }
        public string PlayerUsername { get; private set; }
        public int PlayerCurrency { get; private set; }
        public string PlayerCurrencyName { get; private set; }
        public string PlayerCurrencyCode { get; private set; }
    }
}
