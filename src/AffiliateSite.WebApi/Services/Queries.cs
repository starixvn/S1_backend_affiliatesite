using AffiliateSite.WebApi.Contracts;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using static AffiliateSite.WebApi.Contracts.ReadModels;

namespace AffiliateSite.WebApi.Services
{
    public static class Queries
    {
        public static async Task<ApiListResult<AffiliateStatementHistory>> Query(
            this DbConnection connection,
            QueryModels.GetAffiliateStatementHistory query)
        {
            var para = new DynamicParameters();
            para.Add("_AffId", query.AffId);
            para.Add("_BaseCurrency", query.BaseCurrency);
            para.Add("_PageSize", Math.Abs(query.PageSize));
            para.Add("_StartIndex", (Math.Abs(query.PageNumber) - 1) * Math.Abs(query.PageSize), DbType.Int32, ParameterDirection.Input);
            para.Add("_PageNumber", Math.Abs(query.PageNumber), DbType.Int32, ParameterDirection.InputOutput);
            para.Add("_TotalPages", dbType: DbType.Int32, direction: ParameterDirection.Output);
            para.Add("_RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await connection.QueryAsync<AffiliateStatementHistory>("Affiliate_StatementHistory_Get", para);

            return new ApiListResult<AffiliateStatementHistory>
            {
                Data = result,
                ErrorCode = (int)ErrorCodeEnum.Success,
                PageNumber = para.Get<int?>("_PageNumber") ?? 0,
                TotalPages = para.Get<int?>("_TotalPages") ?? 0,
                RowCount = para.Get<int?>("_RowCount") ?? 0
            };
        }
    }
}
