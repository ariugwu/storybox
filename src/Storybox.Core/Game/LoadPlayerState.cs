using System;
using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Core.Game.Command;
using Storybox.Core.Interpreter;

namespace Storybox.Core.Game
{
    public class LoadPlayerState : GameState
    {
        public LoadPlayerState() : base(new PlayerInterpreter())
        {

        }

        public override void LoadState(IGameContext context)
        {
            context.GameStateType = GameStateType.LoadPlayer;
            context.CurrentCommand = new LoadPlayer();
        }

        public override void DisplayPrompt(IGameContext context)
        {
            Console.WriteLine("Please input player name:"); // Display for the current state.
            Console.Write(">"); // Prompt
        }


        public override void Interpret(ICommand command)
        {
            Interpreter.Interpret(command);
        }

        public override void DisplayResponse(IGameContext context)
        {
            Console.WriteLine("Welcome {0}!", context.Player); // Display output of interpretation
        }

    }
}
