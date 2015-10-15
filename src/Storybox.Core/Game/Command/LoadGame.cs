using Storybox.Common;
using Storybox.Core.Loader;

namespace Storybox.Core.Game.Command
{
    public class LoadGame : Common.Command
    {
        public override void Execute(IGameContext context)
        {
            context.Game = GameFactory.Create(context.GameLibraryItem);
        }
    }
}
