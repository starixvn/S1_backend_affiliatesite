using AffiliateSite.Affiliate;
using AffiliateSite.Auth;
using AffiliateSite.Framework;
using AffiliateSite.Infrastructure;
using AffiliateSite.Users.Domain;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace AffiliateSite.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceType = configuration.GetValue<string>("ServiceType");
            var site = configuration.GetValue<string>("Site");
            var siebogConnection = configuration.GetConnectionString($"{serviceType}_MainDB");
            var conn = siebogConnection.Split(';');
            conn[3] = $"database=Affiliate_{site}";
            var affConnection = string.Join(";", conn);

            services
                .AddScoped<DbConnection>(p => new MySqlConnection(siebogConnection))
                .AddScoped<DbConnection>(p => new MySqlConnection(affConnection));

            return services;
        }


        public static IServiceCollection RegisterServices(this IServiceCollection services) =>
            services
            .AddScoped<CustomCookieAuthenticationEvents>()
            .AddScoped<IAffIInfoRepository, AffInfoRepository>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IUsernameAutoIncrementRepository, UsernameAutoIncrementRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<AffiliateService>()
            .AddScoped<AuthService>();
    }
}
