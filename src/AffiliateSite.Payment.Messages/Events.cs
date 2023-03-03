using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Messages
{
    public static class Events
    {
        public class CreateAffPayout 
        {
            public int AffId { get; set; }
            public decimal Amount { get; set; }
            public DateTime TransDate { get; set; }
        }
        public class CreateAffTrans
        {
            public int RefId { get; set; }
            public int AffId { get; set; }
            public decimal Amount { get; set; }
            public DateTime TransDate { get; set; }
        }
    }
}
