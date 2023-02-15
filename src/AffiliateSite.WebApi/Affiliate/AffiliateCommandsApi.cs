using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using AffiliateSite.Infrastructure;

namespace AffiliateSite.Affiliate
{
    [Route("api/Affiliate")]
    [ApiController]
    public class AffiliateCommandsApi : ControllerBase
    {
        private readonly AffiliateService _affiliateService;
        private static Serilog.ILogger _log = Log.ForContext<AffiliateCommandsApi>();
        public AffiliateCommandsApi(AffiliateService affiliateService) => _affiliateService = affiliateService;

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
