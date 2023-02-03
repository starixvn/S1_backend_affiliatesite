using AffiliateSite.WebApi.Contracts;
using AffiliateSite.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AffiliateSite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        private readonly AffiliateService _affiliateService;
        private static Serilog.ILogger Log = Serilog.Log.ForContext<AffiliateController>();
        public AffiliateController(AffiliateService affiliateService) => _affiliateService = affiliateService;

        [Route("Signup")]
        [HttpPost]
        public async Task<ApiResult> Signup(Affiliates.Signup request) 
        {
            return await HandleRequest(request, _affiliateService.Handle);
        }

        [Route("ChangePassword")]
        [HttpPost]
        public async Task<ApiResult> ChangePassword(Affiliates.ChangePassword request)
        {
            return await HandleRequest(request, _affiliateService.Handle);
        }

        [Route("UpdateInformation")]
        [HttpPost]
        public async Task<ApiResult> UpdateInformation(Affiliates.UpdateInformation request)
        {
            return await HandleRequest(request, _affiliateService.Handle);
        }
        private async Task<ApiResult> HandleRequest<T>(T request, Func<T, Task> handler)
        {
            try
            {
                await handler(request);
                return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Success };
            }
            catch (Exception e)
            {
                Log.Error(e, "Error handling the request");
                return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Failed, Message = e.Message };
            }
        }
    }
}
