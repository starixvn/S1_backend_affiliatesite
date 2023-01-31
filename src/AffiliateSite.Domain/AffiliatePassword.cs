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
        public string Password { get; set; }
        public static AffiliatePassword FromString(string password, ICrypto crypto) => new (password, crypto);

        internal AffiliatePassword(string password, ICrypto crypto)

        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(
                    nameof(password), "password can not be empty");

            var currency = crypto.HashPassword(password);

            Password = password;
        }
        internal AffiliatePassword(string password)
        {
            Password = password;
        }
        public static implicit operator string(AffiliatePassword password) => password.Password;
    }
}
