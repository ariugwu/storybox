using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Storybox.BubbleCommander
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBubbleCommanderGame(this IServiceCollection services)
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
