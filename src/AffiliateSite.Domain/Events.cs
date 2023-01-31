using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public static class Events
    {
        public class AffiliateSignup 
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
        }

        public class AffiliateChangePassword 
        {
            public string UserName { get; set; }
            public string NewPassword { get; set; }
        }
    }
}
