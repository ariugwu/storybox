using Storybox.Common;
using Storybox.Common.Domain.Interpreter;
using Storybox.Common.Domain.Loader;
using Storybox.Common.Game;

namespace Storybox.Core.Domain
{
    public class GameContext : IGameContext
    {

        #region Properties 

        public Expression Interpreter { get; set; }

        public GameLibrary GameLibraryItem { get; set; }

        public IGame Game { get; set; }

        public string Player { get; set; }

        public string UserInput { get; set; }

        public CommandType CurrentCommand { get; set; }

        #endregion


    }
}
