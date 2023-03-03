using AffiliateSite.Payment.Messages;
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
            if (int.TryParse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "user")?.Value, out var affId)) 
            {
                await _payoutService.Handle(command, affId);
            }
        }
    }
}
