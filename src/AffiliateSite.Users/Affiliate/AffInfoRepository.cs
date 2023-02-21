using AffiliateSite.Users.Domain;
using Dapper;
using System.Data;
using System.Data.Common;

namespace AffiliateSite.Users.Affiliate
{
    public class AffInfoRepository : IAffIInfoRepository
    {
        private readonly DbConnection _connection;

        public AffInfoRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task Add(AffInfo entity, DbTransaction transaction)
        {
            await transaction.Connection.ExecuteAsync("Affiliate_AffInfo_Ins", new
            {
                _AffId = (int)entity.Id,
                _UserName = entity.UserName.ToString(),
                _FirstName = entity.FullName.FirstName,
                _LastName = entity.FullName.LastName,
                _Status = entity.Status,
                _Email = entity.Email.ToString(),
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> IsEmailExists(string userNmae)
        {
            var result = await _connection.QueryFirstAsync<bool>("", new { }, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<AffInfo> Load(string userNmae)
        {
            return await _connection.QueryFirstAsync<AffInfo>("Affiliate_AffInfo_Get", new { _UserName = userNmae }, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdatePassword(AffInfo entity)
        {
            await _connection.ExecuteAsync("Affiliate_AffInfoPassword_Set", new { _AffId = (int)entity.Id, _Password = entity.Password.ToString() }, commandType: CommandType.StoredProcedure);
        }
    }
}
