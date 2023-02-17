using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Link.AffiliateLink
{
    public static class ReadModels
    {
        public class AffiliateLinkDomain 
        {
            public int DomainId { get; set; }
            public string DomainName { get; set; }
            public bool IsSSL { get; set; }
        }
    }
}
