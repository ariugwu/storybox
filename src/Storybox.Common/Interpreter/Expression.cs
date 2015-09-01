namespace Storybox.Common.Interpreter
{
    public abstract class Expression
    {
        public abstract void Interpret(IGameContext context);
    }
}
