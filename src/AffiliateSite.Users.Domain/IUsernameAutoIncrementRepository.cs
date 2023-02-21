using System.Data.Common;

namespace AffiliateSite.Users.Domain
{
    public interface IUsernameAutoIncrementRepository
    {
        Task<int> Generate(string prefixName, DbTransaction transaction);
    }
}
