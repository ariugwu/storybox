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

        public virtual void LoadState(IGameContext context)
        {
            // Empty on purpose
        }

        public abstract void DisplayPrompt(IGameContext context);

        public abstract void Interpret(IGameContext context);

        public abstract void DisplayResponse(IGameContext context);

        public virtual void UnloadState(IGameContext context)
        {
            // Empty on purpose
        }

    }
}
