using Storybox.Common.Game;

namespace Storybox.Common
{
    public interface ICommand
    {
        IGameContext GameContext { get; set; }

        CommandType CommandType { get; set; }

        string Parameter { get; set; }

        string UserInput { get; set; }

        void Execute(IGameContext context);
    }
}
