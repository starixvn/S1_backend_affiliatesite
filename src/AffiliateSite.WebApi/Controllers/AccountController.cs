using Microsoft.AspNetCore.Mvc;

namespace AffiliateSite.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public int SignupAsync() 
        {
            return 1;
        }
    }
}
