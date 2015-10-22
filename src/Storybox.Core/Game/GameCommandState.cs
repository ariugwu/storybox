using System;
using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Core.Domain.Interpreter;
using Storybox.Core.Game.Command;

namespace Storybox.Core.Game
{
    public class GameCommandState : GameState
    {
        public GameCommandState() : base(new CommandInterpreter())
        {
        }

        public override void LoadState(IGameContext context)
        {
            context.GameStateType = GameStateType.Playing;
            context.CurrentCommand = new ExecuteGameInstruction();

            context.GameHandler.InitGame(context.Game);
        }

        public override void DisplayPrompt(IGameContext context)
        {
            Console.WriteLine("Please input a command:");
            Console.Write(">");
        }

        public override void Interpret(ICommand command)
        {
            throw new NotImplementedException();
        }

        public override void DisplayResponse(IGameContext context)
        {
            throw new NotImplementedException();
        }

        public override void UnloadState(IGameContext context)
        {
            context.GameHandler.UnloadGame(context.Game);

            base.UnloadState(context);
        }
    }
}
