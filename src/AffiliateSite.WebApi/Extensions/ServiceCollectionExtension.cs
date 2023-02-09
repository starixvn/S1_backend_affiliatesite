using AffiliateSite.Domain;
using AffiliateSite.WebApi.Affiliate;
using AffiliateSite.WebApi.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace AffiliateSite.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration) =>
            services
            .AddScoped<DbConnection>(p => new MySqlConnection(configuration.GetConnectionString("ConnectionString")));
        
        public static IServiceCollection RegisterServices(this IServiceCollection services) =>
            services
            .AddScoped<IAffiliateRepository, AffiliateRepository>()
            .AddScoped<ICrypto, Crypto>()
            .AddScoped<AffiliateService>();
    }
}
