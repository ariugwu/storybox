using Storybox.Common;
using Storybox.Common.Interpreter;

namespace Storybox.Core.Interpreter
{
    

    public class PlayerInterpreter : Expression
    {
        public override void Interpret(IGameContext context)
        {
            context.Player = context.UserInput;
        }
    }
}
