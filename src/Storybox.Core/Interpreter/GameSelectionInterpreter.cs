namespace Storybox.Core.Interpreter
{
    using Common;
    using Common.Interpreter;

    public class GameSelectionInterpreter : Expression
    {
        public override void Interpret(ICommand command)
        {
            command.Parameter = command.UserInput;
        }
    }
}
