using AffiliateSite.Payment.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Payout
{
    public class AffTransRepository
    {
        public async Task<int> Add(AffTrans entity, DbTransaction transaction)
        {
            var p = new DynamicParameters();
            p.Add("_AffId", (int)entity.AffId);
            p.Add("_TransDate", entity.TransDate);
            p.Add("_Amount", entity.Amount);
            p.Add("_Status", entity.Status.ToString());
            p.Add("_Description", entity.Description);
            p.Add("_AffCurrency", entity.Currency);
            p.Add("_AffRate", entity.Rate);
            p.Add("_RefId", (int)entity.RefId);
            p.Add("_TransId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await transaction.Connection.ExecuteAsync("Affiliate_AffTrans_Ins", p, commandType: CommandType.StoredProcedure);
            var transId = p.Get<int?>("_TransId") ?? 0;
            return transId;
        }
    }
}
