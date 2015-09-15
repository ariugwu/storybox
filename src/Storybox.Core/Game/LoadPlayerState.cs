using System;
using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Core.Interpreter;

namespace Storybox.Core.Game
{
    public class LoadPlayerState : GameState
    {
        public LoadPlayerState() : base(new PlayerInterpreter())
        {

        }

        public override void DisplayPrompt(IGameContext context)
        {
            Console.WriteLine("Please input player name:"); // Display for the current state.
            Console.Write(">"); // Prompt
        }

        public override void Interpret(IGameContext context)
        {
            context.GameStateType = GameStateType.LoadPlayer;
            Interpreter.Interpret(context);
        }

        public override void DisplayResponse(IGameContext context)
        {
            Console.WriteLine("Welcome {0}!", context.Player); // Display output of interpretation
        }

    }
}
