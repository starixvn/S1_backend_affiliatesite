using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Users.Domain
{
    public class AffiliateLanguage
    {
        public string Value { get; }
        public AffiliateLanguage(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), " Affiliate language cannot be empty");
            Value = value;
        }
        public static implicit operator string(AffiliateLanguage language) => language.Value;
    }
}
