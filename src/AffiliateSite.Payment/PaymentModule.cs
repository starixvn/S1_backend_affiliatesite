using AffiliateSite.Payment.Payout;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment
{
    public static class PaymentModule
    {
        public static IMvcCoreBuilder AddPaymentModule(this IMvcCoreBuilder builder)
        {
            builder.Services
                .AddScoped<AffPayoutRepository, AffPayoutRepository>()
                .AddScoped<AffTransRepository, AffTransRepository>()
                .AddScoped<ExchangeRateRepository, ExchangeRateRepository>()
                .AddScoped<PayoutService>();
            builder.AddApplicationPart(typeof(PaymentModule).Assembly);
            return builder;
        }
    }
}
