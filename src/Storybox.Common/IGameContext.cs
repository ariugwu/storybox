using Storybox.Common.Game;

namespace Storybox.Common
{
    using Loader;

    public interface IGameContext
    {
        GameHandler GameHandler { get; set; }

        GameState GameState { get; set; }

        GameStateType GameStateType { get; set; }

        GameLibrary GameLibraryItem { get; set; }

        IGame Game { get; set; }

        string Player { get; set; }

        string UserInput { get; set; }
    }
}
