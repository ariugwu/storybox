using Microsoft.Framework.DependencyInjection;
using Storybox.BubbleCommander;
using Storybox.Syn;
using System.Collections.Generic;

namespace Storybox.Cli
{
    static class ServiceExtensions
    {
        public static IServiceCollection AddCommandLine(this IServiceCollection services)
        {
            services.TryAdd(GetDefaultServices());
            return services
                // Consider replacing these direct references with MEF/Assembly scan
                .AddSynGame()
                .AddBubbleCommanderGame();
        }

        public static IEnumerable<ServiceDescriptor> GetDefaultServices()
        {
            yield return ServiceDescriptor.Transient<GameFactory, PreResolvedGameFactory>();
            yield return ServiceDescriptor.Transient<CommandLine, ConsoleCommandLine>();
            yield return ServiceDescriptor.Transient<ResourceDictionary, HardcodedEnglishResourceDictionary>();
            yield return ServiceDescriptor.Transient<SelectGame, SelectGame>();
        }
    }
}
