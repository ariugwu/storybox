namespace Storybox.Common.Interpreter
{
    public abstract class Expression
    {
        public ICommand Command { get; set; }

        public abstract void Interpret(ICommand command);
    }
}
