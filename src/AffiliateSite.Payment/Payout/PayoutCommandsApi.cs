using AffiliateSite.Payment.Messages;
using AffiliateSite.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AffiliateSite.Payment.Payout
{
    [Authorize, ApiController, Route("api/Payout")]
    public class PayoutCommandsApi : ControllerBase
    {
        private readonly PayoutService _payoutService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PayoutCommandsApi(IHttpContextAccessor httpContextAccessor, PayoutService payoutService)
        {
            _payoutService = payoutService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost, Route("Apply")]
        public async void Apply(Commands.Payout command) 
        {
            if (_httpContextAccessor.TryParse(out var authData))
            {
                await _payoutService.Handle(command, authData.AffId);
            }
        }
    }
}
