using Storybox.Common.Game;

namespace Storybox.Common
{
    public abstract class Command : ICommand
    {
        public IGameContext GameContext { get; set; }

        public CommandType CommandType { get; set; }

        public string Parameter { get; set; }

        public string UserInput { get; set; }

        public abstract void Execute(IGameContext context);
    }
}
