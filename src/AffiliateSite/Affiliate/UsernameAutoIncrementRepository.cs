using AffiliateSite.Users.Domain;
using Dapper;
using System.Data;
using System.Data.Common;

namespace AffiliateSite.Affiliate
{
    public class UsernameAutoIncrementRepository : IUsernameAutoIncrementRepository
    {
        public async Task<int> Generate(string prefixName, DbTransaction transaction)
        {
            var para = new DynamicParameters();
            para.Add("_PrefixName", prefixName);
            para.Add("_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await transaction.Connection.ExecuteAsync("Affiliate_GenerateId", para, commandType: CommandType.StoredProcedure);
            var id = para.Get<int?>("_Id") ?? 0;
            return id;
        }
    }
}
