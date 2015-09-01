namespace Storybox.Core.Interpreter
{
    using Common;
    using Common.Interpreter;
    using Common.Loader;

    public class GameSelectionInterpreter : Expression
    {
        public override void Interpret(IGameContext context)
        {
            context.GameLibraryItem = (GameLibrary)int.Parse(context.UserInput);
        }
    }
}
