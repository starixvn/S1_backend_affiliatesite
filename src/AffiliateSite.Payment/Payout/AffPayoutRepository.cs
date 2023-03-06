using AffiliateSite.Payment.Domain;
using Dapper;
using System.Data;
using System.Data.Common;

namespace AffiliateSite.Payment.Payout
{
    public class AffPayoutRepository
    {
        private readonly DbConnection _connection;

        public AffPayoutRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Add(AffPayout entity, DbTransaction transaction) 
        {
            var p = new DynamicParameters();
            p.Add("_AffId", (int)entity.AffId);
            p.Add("_TransDate", entity.TransDate);
            p.Add("_Amount", entity.Amount);
            p.Add("_AffPayout", entity.Payout);
            p.Add("_AffCurrency", entity.Currency);
            p.Add("_AffRate", entity.Rate);
            p.Add("_PreferredPayment", entity.PreferredPayment);
            p.Add("_Player_CustId", entity.PlayerCustId);
            p.Add("_Player_Username", entity.PlayerUsername);
            p.Add("_Player_Currency", entity.PlayerCurrency);
            p.Add("_Player_CurrencyName", entity.PlayerCurrencyName);
            p.Add("_Player_CurrencyCode", entity.PlayerCurrencyCode);
            p.Add("_RefId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await transaction.Connection.ExecuteAsync("Affiliate_AffPayout_Ins", p, commandType: CommandType.StoredProcedure);
            var refId = p.Get<int?>("_RefId") ?? 0;
            return refId;
        }

        public async Task<bool> IsExistsPending(int affId) =>
            await _connection.ExecuteScalarAsync<bool>(
                "Affiliate_PendingAffPayout_Check",
                new { _AffId = affId }, 
                commandType: CommandType.StoredProcedure);


        public async Task<ReadModels.Information> GetInformation(int affId) =>
            await _connection.QueryFirstOrDefaultAsync<ReadModels.Information>(
                "Affiliate_PaymentInformation_Get", 
                new { _AffId = affId }, 
                commandType: CommandType.StoredProcedure);

        public async Task<IEnumerable<ReadModels.History>> GetHistory(int affId, int year) =>
            await _connection.QueryAsync<ReadModels.History>(
                "Affiliate_PaymentRequest_Get",
                new { _AffId = affId, _Year = new DateTime(year, 1, 1) },
                commandType: CommandType.StoredProcedure);
    }

}
