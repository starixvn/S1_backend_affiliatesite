using AffiliateSite.Infrastructure;
using Dapper;
using System.Data;
using System.Data.Common;
using static AffiliateSite.Link.Marketing.ReadModels;

namespace AffiliateSite.Link.Marketing
{
    public static class Queries
    {
        public static async Task<ApiResult<IEnumerable<LinkDomain>>> Query(this DbConnection connection, QueryModels.GetAffiliateLinkDomain request, int affId)
        {
            var sp = request.LinkType switch
            {
                0 => "Affiliate_Domain_Get",
                1 => "Affiliate_SubAffiliateDomain_Sel",
                _ => throw new ArgumentException()
            };
            return new ApiResult<IEnumerable<LinkDomain>>
            {
                Data = await connection
                    .QueryAsync<LinkDomain>(
                    sp,
                    new { _AffId = affId },
                    commandType: CommandType.StoredProcedure),
                ErrorCode = (int)ErrorCodeEnum.Success
            };
        }

        public static async Task<ApiResult<IEnumerable<LinkHistory>>> Query(this DbConnection connection, int affId) =>
            new ApiResult<IEnumerable<LinkHistory>>
            {
                Data = await connection
                .QueryAsync<LinkHistory>(
                    "Affiliate_AffMediaChannel_Statistics", 
                    new { _AffId = affId },
                    commandType: CommandType.StoredProcedure),
                ErrorCode = (int)ErrorCodeEnum.Success
            };
    }
}
