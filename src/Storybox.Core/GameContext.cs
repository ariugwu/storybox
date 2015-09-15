using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Common.Loader;
using Storybox.Core.Game;
using Storybox.Core.Game.Handler;

namespace Storybox.Core
{
    public class GameContext : IGameContext
    {
        #region Constructor(s)
        
        public GameContext()
        {
            GameState = new LoadPlayerState();

            GameHandler = new PlayerLoadHandler();

            var gameSelectionHandler = new GameSelectionHandler();
            var gameCommandHandler = new GameCommandHandler();

            GameHandler.SetSuccessor(gameSelectionHandler);
            gameSelectionHandler.SetSuccessor(gameCommandHandler);
        }

        #endregion

        #region Properties

        public GameHandler GameHandler { get; set; }

        public GameStateType GameStateType { get; set; }

        public GameState GameState { get; set; }

        public GameLibrary GameLibraryItem { get; set; }

        public IGame Game { get; set; }

        public string Player { get; set; }

        public string UserInput { get; set; }

        public CommandType CurrentCommand { get; set; }

        #endregion

        #region Method(s)

        public void Process()
        {
            GameHandler.Process(this);
        }

        #endregion

    }
}
