using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Multitenancy.Library.Extensions
{
    public static class MultitenancyServiceCollectionExtensions
    {
        public static IServiceCollection AddMultitenancy<TTenant, TResolver>(this IServiceCollection services)
            where TResolver : class, ITenantResolver<TTenant>
            where TTenant : class
        {
            services.AddScoped<ITenantResolver<TTenant>, TResolver>();
            services.AddScoped(sp => sp.GetService<ITenantResolver<TTenant>>()!.Tenant!);
            return services;
        }
    }
}
