using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Link.Messages.MediaLink
{
    public static class Events
    {
        public class CreateMarketingLink
        {
            public int Id { get; set; }
            public int AffId { get; set; }
            public string ChannelCode { get; set; }
            public string LanguageCode { get; set; }
            public string AffLink { get; set; }
        }

        public class ToggleStatus 
        {
            public int Status { get; set; }
        }
    }
}
