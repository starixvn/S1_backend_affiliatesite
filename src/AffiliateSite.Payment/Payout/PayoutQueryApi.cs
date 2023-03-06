using AffiliateSite.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AffiliateSite.Payment.Payout
{
    [Authorize, ApiController, Route("/api/Payout")]
    public class PayoutQueryApi : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AffPayoutRepository _affPayoutRepository;

        public PayoutQueryApi(AffPayoutRepository affPayoutRepository, IHttpContextAccessor httpContextAccessor)
        {
            _affPayoutRepository = affPayoutRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost, Route("GetInformation")]
        public async Task<ReadModels.Information> GetInformation()
        {
            if (_httpContextAccessor.TryParse(out var authData))
            {
                return await _affPayoutRepository.GetInformation(authData.AffId);
            }
            return new ReadModels.Information();
        }

        [HttpPost, Route("GetHistory")]
        public async Task<IEnumerable<ReadModels.History>> GetHistory(QueryModels.History request)
        {
            if (_httpContextAccessor.TryParse(out var authData))
            {
                return await _affPayoutRepository.GetHistory(authData.AffId, request.Year);
            }
            return null;
        }
    }
}
