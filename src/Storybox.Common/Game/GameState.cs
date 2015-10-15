using Storybox.Common.Interpreter;

namespace Storybox.Common.Game
{
    public abstract class GameState
    {
        protected GameState(Expression interpreter)
        {
            _interpreter = interpreter;
        }

        private Expression _interpreter;

        protected Expression Interpreter
        {
            get
            {
                return _interpreter;
            }
        }

        public abstract void LoadState(IGameContext context);

        public abstract void DisplayPrompt(IGameContext context);

        public abstract void Interpret(ICommand command);

        public virtual void Process(IGameContext context)
        {
         // EMPTY ON PURPOSE   
        }

        public virtual void ExecuteCommand(IGameContext context)
        {
            context.CurrentCommand.Execute(context);
        }

        public abstract void DisplayResponse(IGameContext context);

        public virtual void UnloadState(IGameContext context)
        {
            // Empty on purpose
        }

    }
}
