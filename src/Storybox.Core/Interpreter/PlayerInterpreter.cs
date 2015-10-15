using Storybox.Common;
using Storybox.Common.Interpreter;

namespace Storybox.Core.Interpreter
{
    public class PlayerInterpreter : Expression
    {
        public override void Interpret(ICommand command)
        {
            command.Parameter = command.UserInput;
        }
    }
}
