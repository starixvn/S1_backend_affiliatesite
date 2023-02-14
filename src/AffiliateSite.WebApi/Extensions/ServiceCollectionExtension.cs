using AffiliateSite.Domain;
using AffiliateSite.Framework;
using AffiliateSite.WebApi.Affiliate;
using AffiliateSite.WebApi.Infrastructure;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace AffiliateSite.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration) 
        {
            var serviceType = configuration.GetValue<string>("ServiceType");
            var connectionStr = configuration.GetConnectionString($"{serviceType}_MainDB");
            var conAttribute = connectionStr.Split(';');
            conAttribute[3] = "database=Affiliate_N88";
            var affConnection = string.Join(";", conAttribute);

            services
                .AddScoped<DbConnection>(p => new MySqlConnection(affConnection));

            return services;
        }
            
        
        public static IServiceCollection RegisterServices(this IServiceCollection services) =>
            services
            .AddScoped<IAffIInfoRepository, AffInfoRepository>()
            .AddScoped<IUsernameAutoIncrementRepository, UsernameAutoIncrementRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<ICrypto, Crypto>()
            .AddScoped<AffiliateService>();
    }
}
