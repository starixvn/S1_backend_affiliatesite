using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AffiliateSite.WebApi.Auth
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthApi : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthApi(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route("Signin")]
        public async Task<IActionResult> Signin(Contracts.Signin request) 
        {
            var affInfo = await _authService.Sign(request.UserName, request.Password);

            var claims = new List<Claim>
            {
                new Claim("user", affInfo.AffId.ToString()),
                new Claim("name", request.UserName),
                new Claim("role", "Affiliate")
            };
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        "user", "role"
                    )
                ),
                authProperties
            );

            return Ok();
        }

        [HttpPost, Route("Signout")]
        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
