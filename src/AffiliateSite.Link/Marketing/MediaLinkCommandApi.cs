using AffiliateSite.WebApi;
using AffiliateSite.Link.Messages.MediaLink;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AffiliateSite.Link.Marketing
{
    [Authorize, ApiController, Route("api/MediaLink")]
    public class MediaLinkCommandApi : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MediaLinkService _mediaLinkService;
        private readonly ILogger _log;

        public MediaLinkCommandApi(IHttpContextAccessor httpContextAccessor, MediaLinkService mediaLinkService, ILoggerFactory logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediaLinkService = mediaLinkService;
            _log = logger.CreateLogger(GetType());
        }

        [HttpPost, Route("Toggle")]
        public async Task<ApiResult> Toggle(Commands.ToggleMarketingLink request)
        {
            if (_httpContextAccessor.TryParse(out var authData))
            {
                await _mediaLinkService.Handle(request, authData.AffId);
                return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Success };
            }
            return new ApiResult();
        }
    }
}
