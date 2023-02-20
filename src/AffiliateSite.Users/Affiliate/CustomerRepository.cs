using AffiliateSite.Users.Domain;
using Dapper;
using System.Data;
using System.Data.Common;

namespace AffiliateSite.Users.Affiliate
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbConnection _connection;

        public CustomerRepository(IEnumerable<DbConnection> connections)
        {
            _connection = connections.FirstOrDefault(a => a.Database == "Siebog");
        }

        public async Task<Customer> Load(string playerUserName)
        {
            return await _connection.QueryFirstOrDefaultAsync<Customer>("Affiliate_Customer_Get", new { _UserName = playerUserName, _SiteId = 1 }, commandType: CommandType.StoredProcedure);
        }
    }
}
