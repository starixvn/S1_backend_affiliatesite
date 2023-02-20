using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Users.Domain
{
    public class AffiliatePassword : ValueObject<AffiliatePassword>
    {
        public string Value { get; private set; }
        public static AffiliatePassword FromString(string password) => new(password);
        internal AffiliatePassword(string password)
        {
            Value = password;
        }
        public static implicit operator string(AffiliatePassword password) => password.Value;
        public static implicit operator AffiliatePassword(string value) => new AffiliatePassword(value);
    }
}
