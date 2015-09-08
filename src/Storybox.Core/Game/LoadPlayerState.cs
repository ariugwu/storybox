using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Core.Domain.Interpreter;

namespace Storybox.Core.Game
{
    public class LoadPlayerState : GameState
    {
        public LoadPlayerState() : base(new PlayerInterpreter())
        {

        }

        public override void Interpret(IGameContext context)
        {
            context.GameStateType = GameStateType.LoadPlayer;
            Interpreter.Interpret(context);
        }
    }
}
