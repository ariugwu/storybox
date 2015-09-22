using Storybox.Common;
using Storybox.Common.Game;

namespace Storybox.Core.Game.Handler
{
    public class GameCommandHandler : GameHandler
    {
        public override void HandleRequest(IGameContext gameContext)
        {
            gameContext.GameStateType = GameStateType.Playing;
            gameContext.GameState = new GameCommandState();
        }
    }
}
