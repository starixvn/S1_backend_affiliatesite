using AffiliateSite.Infrastructure;
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
        private IHttpContextAccessor _httpContextAccessor;

        public MediaLinkQueryApi(DbConnection connection, IHttpContextAccessor httpContextAccessor)
        {
            _connection = connection;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost, Route("GetDomain")]
        public async Task<ApiResult> GetDomain(QueryModels.GetAffiliateLinkDomain request)
        {
            if (int.TryParse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "user")?.Value, out var affId))
            {
                return await _connection.Query(request, affId);
            }
            return new ApiResult();
        }
    }
}
