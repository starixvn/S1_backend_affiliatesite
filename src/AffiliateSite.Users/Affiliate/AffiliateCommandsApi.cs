using Microsoft.AspNetCore.Mvc;
using AffiliateSite.Infrastructure;
using AffiliateSite.Users.Messages.Affiliate;
using Microsoft.Extensions.Logging;

namespace AffiliateSite.Users.Affiliate
{
    [Route("api/Affiliate")]
    [ApiController]
    public class AffiliateCommandsApi : ControllerBase
    {
        private readonly AffiliateService _affiliateService;
        private readonly ILogger _log;
        public AffiliateCommandsApi(AffiliateService affiliateService, ILoggerFactory logger) 
        {
            _log = logger.CreateLogger(GetType());
            _affiliateService = affiliateService;
        } 

        [Route("Signup")]
        [HttpPost]
        public Task<ApiResult> Signup(Commands.Signup request)
        {
            return RequestHandler.HandleCommand(request, _affiliateService.Handle, _log);
        }

        [Route("ChangePassword")]
        [HttpPost]
        public Task<ApiResult> ChangePassword(Commands.ChangePassword request)
        {
            return RequestHandler.HandleCommand(request, _affiliateService.Handle, _log);
        }

        [Route("UpdateInformation")]
        [HttpPost]
        public Task<ApiResult> UpdateInformation(Commands.UpdateInformation request)
        {
            return RequestHandler.HandleCommand(request, _affiliateService.Handle, _log);
        }
    }
}
