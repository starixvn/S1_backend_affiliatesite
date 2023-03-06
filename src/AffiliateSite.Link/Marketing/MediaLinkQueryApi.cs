using AffiliateSite.Infrastructure;
using AffiliateSite.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace AffiliateSite.Link.Marketing
{
    [Authorize, ApiController, Route("/api/MediaLink")]
    public class MediaLinkQueryApi : ControllerBase
    {
        private readonly DbConnection _connection;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MediaLinkQueryApi(DbConnection connection, IHttpContextAccessor httpContextAccessor)
        {
            _connection = connection;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost, Route("GetDomain")]
        public async Task<ApiResult> GetDomain(QueryModels.GetAffiliateLinkDomain request)
        {
            if (_httpContextAccessor.TryParse(out var authData))
            {
                return await _connection.Query(request, authData.AffId);
            }
            return new ApiResult();
        }

        [HttpPost, Route("GetHistory")]
        public async Task<ApiResult> GetHistory() 
        {
            if (_httpContextAccessor.TryParse(out var authData))
            {
                return await _connection.Query(authData.AffId);
            }
            return new ApiResult();
        }
    }
}
