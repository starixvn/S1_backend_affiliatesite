using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Payout
{
    public static class ReadModels
    {
        public class Information 
        {
            public string PreferredPayment { get; set; }
            public decimal BalBroughtForward { get; set; }
            public decimal MinAmount { get; set; }
        }

        public class History 
        {
            public int TransId { get; set; }
            public int RefId { get; set; }
            public DateTimeOffset TransDate { get; set; }
            public DateTimeOffset? CompletedDate { get; set; }
            public string Status { get; set; }
            public decimal Amount { get; set; }
            public string AffDesc { get; set; }
        }
    }
}
