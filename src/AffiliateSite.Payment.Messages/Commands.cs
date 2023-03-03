using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Messages
{
    public static class Commands
    {
        public class Payout 
        {
            public decimal Amount { get; set; }
        }
    }
}
