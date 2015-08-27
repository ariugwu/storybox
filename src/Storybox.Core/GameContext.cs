using Storybox.Common;

namespace Storybox.Core
{
    using Storybox.Common.Interpreter;
    using Storybox.Common.Loader;

    public class GameContext : IGameContext
    {
        public Expression Interpreter { get; set; }

        public GameLibrary GameLibraryItem { get; set; }

        public IGame Game { get; set; }

        public string Player { get; set; }

        public string UserInput { get; set; }
    }
}
