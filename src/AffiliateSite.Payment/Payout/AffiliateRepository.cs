using AffiliateSite.Payment.Domain.Affiliate;
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
    public class AffiliateRepository
    {
        private readonly DbConnection _connection;

        public AffiliateRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<AffInfo> GetById(int affId) =>
            await _connection.QueryFirstOrDefaultAsync<AffInfo>(
                "Affiliate_AffInfoById_Get",
                new { _AffId = affId },
                commandType: CommandType.StoredProcedure);
    }
}
