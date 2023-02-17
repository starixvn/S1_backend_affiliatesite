using Dapper;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AffiliateSite.Link.AffiliateLink.ReadModels;

namespace AffiliateSite.Link.AffiliateLink
{
    public static class Queries
    {
        public static async Task<ApiResult<IEnumerable<AffiliateLinkDomain>>> Query(this DbConnection connection, QueryModels.GetAffiliateLinkDomain request, int affId) 
        {
            var sp = request.LinkType switch 
            {
                0 => "Affiliate_Domain_Get",
                1 => "Affiliate_SubAffiliateDomain_Sel",
                _ => throw new ArgumentException()
            };
            return new ApiResult<IEnumerable<AffiliateLinkDomain>>
            {
                Data = await connection
                    .QueryAsync<AffiliateLinkDomain>(sp, new { _AffId = affId }, commandType: CommandType.StoredProcedure),
                ErrorCode = (int)ErrorCodeEnum.Success
            };
        }
    }
}
