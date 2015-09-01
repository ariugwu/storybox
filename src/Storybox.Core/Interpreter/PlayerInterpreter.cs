using Storybox.Common;

namespace Storybox.Core.Domain.Interpreter
{
    using Storybox.Common.Interpreter;

    public class PlayerInterpreter : Expression
    {
        public override void Interpret(IGameContext context)
        {
            context.Player = context.UserInput;
        }
    }
}
