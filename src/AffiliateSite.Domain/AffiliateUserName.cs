using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class AffiliateUserName : ValueObject<AffiliateUserName>
    {
        public string Value { get; }
        public AffiliateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName), " Affiliate user name cannot be empty");

            Value = userName;
        }
        public AffiliateUserName(string prefixName, int id)
        {
            if (string.IsNullOrEmpty(prefixName))
                throw new ArgumentNullException(nameof(prefixName), " Affiliate prefixName cannot be empty");

            Value = prefixName + id.ToString("D3");
        }
        public static implicit operator string(AffiliateUserName userName) => userName.Value;
        public static implicit operator AffiliateUserName(string value) => new(value);
    }
}
