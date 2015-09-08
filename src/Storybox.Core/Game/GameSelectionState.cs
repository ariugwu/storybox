using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Core.Interpreter;

namespace Storybox.Core.Game
{
    public class GameSelectionState : GameState
    {
        public GameSelectionState() : base(new GameSelectionInterpreter())
        {
        }

        public override void Interpret(IGameContext context)
        {
            context.GameStateType = GameStateType.GameSelection;
            Interpreter.Interpret(context);
        }
    }
}
