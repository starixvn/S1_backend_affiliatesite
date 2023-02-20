using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Users.Domain
{
    public class Customer
    {
        public int CustId { get; set; }
        public int SiteId { get; set; }
        public string UserName { get; set; }
    }
}
