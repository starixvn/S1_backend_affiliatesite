using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class AffiliateUserName : IEquatable<AffiliateUserName>
    {
        public string UserName { get; }
        public AffiliateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName), " Affiliate user name cannot be empty");

            UserName = userName;
        }
        public static implicit operator string(AffiliateUserName userName) => userName.UserName;
        public bool Equals(AffiliateUserName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return UserName.Equals(other.UserName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AffiliateUserName)obj);
        }

        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }
    }
}
