using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Storybox.Core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.TryAdd(GetDefaultServices());
            return services;
        }

        public static IEnumerable<ServiceDescriptor> GetDefaultServices()
        {
            yield break;
        }
    }
}
