using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Common.Loader;
using Storybox.Core.Game;

namespace Storybox.Core
{
    public class GameContext : IGameContext
    {
        #region Constructor(s)
        
        public GameContext()
        {
            GameState = new LoadPlayerState();
        }

        #endregion

        #region Properties

        public GameStateType GameStateType { get; set; }

        public GameState GameState { get; set; }

        public GameLibrary GameLibraryItem { get; set; }

        public IGame Game { get; set; }

        public string Player { get; set; }

        public string UserInput { get; set; }

        public CommandType CurrentCommand { get; set; }

        #endregion

        #region Method(s)

        public void Interpret()
        {
            GameState.Interpret(this);
        }

        #endregion

    }
}
