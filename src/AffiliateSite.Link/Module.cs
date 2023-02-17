using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Link
{
    public static class Module
    {
        public static IServiceCollection AddLinkModule(this IServiceCollection builder, string databaseName) 
        {
            return builder;
        }
    }
}
