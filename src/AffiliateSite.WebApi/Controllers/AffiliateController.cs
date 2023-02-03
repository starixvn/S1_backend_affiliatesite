using AffiliateSite.WebApi.Contracts;
using AffiliateSite.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AffiliateSite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        private readonly AffiliateService _affiliateService;
        public AffiliateController(AffiliateService affiliateService) => _affiliateService = affiliateService;

        [Route("Signup")]
        [HttpPost]
        public async Task<ApiResult> Signup(Affiliates.Signup request) 
        {
            await _affiliateService.Handle(request);
            return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Success };
        }

        [Route("ChangePassword")]
        [HttpPost]
        public async Task<ApiResult> ChangePassword(Affiliates.ChangePassword request)
        {
            await _affiliateService.Handle(request);
            return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Success };
        }

        [Route("UpdateInformation")]
        [HttpPost]
        public async Task<ApiResult> UpdateInformation(Affiliates.UpdateInformation request)
        {
            await _affiliateService.Handle(request);
            return new ApiResult() { ErrorCode = (int)ErrorCodeEnum.Success };
        }
    }
}
