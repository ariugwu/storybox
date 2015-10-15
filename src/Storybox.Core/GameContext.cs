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

            GameHandler = _playerloadHandler;

            GameHandler.SetSuccessor(_gameSelectionHandler);
            _gameSelectionHandler.SetSuccessor(_gameCommandHandler);
        }

        #endregion

        private GameHandler _playerloadHandler = new PlayerLoadHandler();
        private GameHandler _gameSelectionHandler = new GameSelectionHandler();
        private GameHandler _gameCommandHandler = new GameCommandHandler();

        #region Properties

        public GameHandler GameHandler { get; set; }

        public GameStateType GameStateType { get; set; }

        public GameState GameState { get; set; }

        public GameLibrary GameLibraryItem { get; set; }

        public IGame Game { get; set; }

        public string Player { get; set; }

        public ICommand CurrentCommand { get; set; }

        #endregion

        #region Method(s)

        public void Start()
        {
            GameHandler.Process(this);
        }

        public void SetGameSelectionHandler(GameHandler handler)
        {
            _gameSelectionHandler = handler;
            _gameSelectionHandler.SetSuccessor(_gameCommandHandler);
        }

        #endregion

    }
}
