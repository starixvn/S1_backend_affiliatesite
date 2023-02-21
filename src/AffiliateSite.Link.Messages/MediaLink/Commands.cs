using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Link.Messages.MediaLink
{
    public static class Commands
    {
        public class ToggleMarketingLink 
        {
            public string ChannelCode { get; set; }
            public string LanguageCode { get; set; }
            public string AffLink { get; set; }
            public int IsOn { get; set; }
        }
    }
}
