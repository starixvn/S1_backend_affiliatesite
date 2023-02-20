using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Users.Domain
{
    public class AffiliateContactApp : ValueObject<AffiliateContactApp>
    {
        public string Skype { get; }
        public string QQ { get; }
        public AffiliateContactApp(string skype, string qq)
        {
            Skype = skype;
            QQ = qq;
        }
    }
}
