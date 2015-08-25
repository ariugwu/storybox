using Storybox.Core;

namespace Storybox.Cli
{
    interface GameFactory
    {
        Game Resolve(string gameName);
    }
}
