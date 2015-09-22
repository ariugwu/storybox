using Storybox.Common;
using Storybox.Common.Game;

namespace Storybox.Core.Game.Handler
{
    public class GameSelectionHandler : GameHandler
    {
        public override void HandleRequest(IGameContext gameContext)
        {
            gameContext.GameStateType = GameStateType.GameSelection;
            gameContext.GameState = new GameSelectionState();
        }
    }
}
