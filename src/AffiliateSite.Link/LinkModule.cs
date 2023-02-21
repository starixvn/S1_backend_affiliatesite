using AffiliateSite.Framework;
using AffiliateSite.Link.Domain;
using AffiliateSite.Link.Marketing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Link
{
    public static class LinkModule
    {
        public static IMvcCoreBuilder AddLinkModule(this IMvcCoreBuilder builder) 
        {
            builder.Services
                .AddScoped<IMediaLinkRepository, MediaLinkRepository>()
                .AddScoped<MediaLinkService>();
            builder.AddApplicationPart(typeof(LinkModule).Assembly);
            return builder;
        }
    }
}
