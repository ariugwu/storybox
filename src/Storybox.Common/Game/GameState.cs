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

        public abstract void Interpret(IGameContext context);
    }
}
