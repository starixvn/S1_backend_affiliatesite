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
        public static IMvcCoreBuilder AddUsersModule(this IMvcCoreBuilder builder) 
        {
            builder.Services
                .AddScoped<IAffIInfoRepository, AffInfoRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IUsernameAutoIncrementRepository, UsernameAutoIncrementRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<AffiliateService>()
                .AddScoped<AuthService>();

            builder.AddApplicationPart(typeof(UsersModule).Assembly);

            return builder;
        }
    }
}
