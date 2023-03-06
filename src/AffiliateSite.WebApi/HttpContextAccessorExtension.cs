using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.WebApi
{
    public static class HttpContextAccessorExtension
    {
        public static bool TryParse(this IHttpContextAccessor httpContextAccessor, out AuthData authData) 
        {
            authData = new AuthData();
            if (httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated == false)
                return false;

            var claims = httpContextAccessor.HttpContext.User.Claims;
            if (int.TryParse(claims.FirstOrDefault(a => a.Type == "user")?.Value, out var affId)) 
            {
                authData.AffId = affId;
                authData.UserName = claims.FirstOrDefault(a => a.Type == "name").Value;
                authData.Role = claims.FirstOrDefault(a => a.Type == "role").Value;
                return true;
            }
            return false;
        }
    }

    public class AuthData
    {
        public int AffId { set; get; }
        public string UserName { set; get; }
        public string Role { set; get; }
        public string Language { get; set; }
    }
}
