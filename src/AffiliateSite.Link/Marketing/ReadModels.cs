using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Link.Marketing
{
    public static class ReadModels
    {
        public class LinkDomain
        {
            public int DomainId { get; set; }
            public string DomainName { get; set; }
            public bool IsSSL { get; set; }
        }

        public class LinkHistory 
        {
            public string ChannelCode { get; set; }
            public string ChannelName { get; set; }
            public string AffMediaLink { get; set; }
            public string MarketName { get; set; }
        }
    }
}
