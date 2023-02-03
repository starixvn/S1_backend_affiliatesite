using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class AffiliatePassword : ValueObject<AffiliatePassword>
    {
        public string Value { get; private set; }
        public static AffiliatePassword FromString(string password, ICrypto crypto) => new (password, crypto);

        internal AffiliatePassword(string password, ICrypto crypto)

        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(
                    nameof(password), "password can not be empty");

            var hashPassword = crypto.HashPassword(password);

            Value = hashPassword;
        }
        internal AffiliatePassword(string password)
        {
            Value = password;
        }
        public static implicit operator string(AffiliatePassword password) => password.Value;
    }
}
