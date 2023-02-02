using AffiliateSite.Domain;
using AffiliateSite.WebApi.Infrastructure;
using AffiliateSite.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AffiliateSite.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) =>
            services
            .AddScoped<IAffiliateRepository, AffiliateRepository>()
            .AddScoped<ICrypto, Crypto>()
            .AddScoped<AffiliateService>();
    }
}
