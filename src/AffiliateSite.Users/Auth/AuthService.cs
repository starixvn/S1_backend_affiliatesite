using AffiliateSite.Infrastructure;
using System.Data.Common;
using AffiliateSite.Users.Affiliate;

namespace AffiliateSite.Users.Auth
{
    public class AuthService
    {
        private readonly DbConnection _connection;

        public AuthService(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ReadModels.AffInfo> Sign(string userName, string password)
        {
            var affInfo = await _connection.GetAffInfo(userName);
            if (!string.Equals(affInfo.Password, CryptographyHelper.Encrypt(password)))
                throw new Exception("wrong password");

            return affInfo;
        }
    }
}
