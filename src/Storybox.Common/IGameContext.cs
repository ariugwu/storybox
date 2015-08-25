using Storybox.Common.Domain.Loader;

namespace Storybox.Common
{
    public interface IGameContext
    {
        GameLibrary GameLibraryItem { get; set; }

        IGame Game { get; set; }

        string Player { get; set; }

        string UserInput { get; set; }
    }
}
