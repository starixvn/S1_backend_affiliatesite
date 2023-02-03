using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class AffiliatePhone
    {
        public string Value { get; }
        public static AffiliatePhone FromString(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("phone cannot be empty");
            return new AffiliatePhone(value);
        }
        internal AffiliatePhone(string value) => Value = value;

        public static implicit operator string(AffiliatePhone email) => email.Value;
    }
    
}
