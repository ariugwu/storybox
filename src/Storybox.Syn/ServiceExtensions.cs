using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Storybox.Syn
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddSynGame(this IServiceCollection services)
        {
            services.TryAdd(GetDefaultServices());
            return services
                .AddTransient<Core.Game, Game>();
        }

        public static IEnumerable<ServiceDescriptor> GetDefaultServices()
        {
            yield break;
        }
    }
}
