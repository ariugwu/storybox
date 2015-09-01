using Storybox.Common;
using Storybox.Common.Domain.Interpreter;
using Storybox.Common.Domain.Loader;

namespace Storybox.Core.Domain.Interpreter
{
    public class PlayerInterpreter : Expression
    {
        public override void Interpret(IGameContext context)
        {
            context.Player = context.UserInput;
        }
    }
}
