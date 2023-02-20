using AffiliateSite.Framework;
using AffiliateSite.Users.Affiliate;
using AffiliateSite.Users.Auth;
using AffiliateSite.Users.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Users
{
    public static class UsersModule
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services) =>
            services
            
            .AddScoped<IAffIInfoRepository, AffInfoRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IUsernameAutoIncrementRepository, UsernameAutoIncrementRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<AffiliateService>()
            .AddScoped<AuthService>();
    }
}
