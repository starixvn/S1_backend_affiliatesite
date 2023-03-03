using AffiliateSite.Payment.Domain.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Payout
{
    public class ExchangeRateRepository
    {
        private readonly DbConnection _connection;

        public ExchangeRateRepository(IEnumerable<DbConnection> connections)
        {
            _connection = connections.FirstOrDefault(a => a.Database == "Siebog");
        }

        public async Task<ExchangeRate> Query(int currencyId, int targetCurrencyId, DateTime rateDate) =>
            await _connection.QueryFirstOrDefaultAsync<ExchangeRate>("Affiliate_ExchangeRate_Get",
                new { _CurrencyId = currencyId, _TargetCurrencyId = targetCurrencyId, _RateDate = rateDate },
                commandType: CommandType.StoredProcedure);
    }
}
