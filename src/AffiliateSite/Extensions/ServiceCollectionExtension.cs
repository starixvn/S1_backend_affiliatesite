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
    }
}
