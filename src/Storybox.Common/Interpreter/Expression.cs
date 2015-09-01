namespace Storybox.Common.Domain.Interpreter
{
    public abstract class Expression
    {
        public abstract void Interpret(IGameContext context);
    }
}
