using System;
using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Common.Loader;
using Storybox.Core.Game.Command;
using Storybox.Core.Interpreter;

namespace Storybox.Core.Game
{
    public class GameSelectionState : GameState
    {
        public GameSelectionState() : base(new GameSelectionInterpreter())
        {
        }

        public override void DisplayPrompt(IGameContext context)
        {
            Console.WriteLine("1. Bubble Commander");
            Console.WriteLine("2. Syn");
            Console.WriteLine("Please type the game you want to play:");
            Console.Write(">");
        }

        public override void LoadState(IGameContext context)
        {
            context.GameStateType = GameStateType.GameSelection;
            context.CurrentCommand = new LoadGame();
        }

        public override void Interpret(ICommand command)
        {
            Interpreter.Interpret(command);        
        }

        public override void Process(IGameContext context)
        {
            context.GameLibraryItem = (GameLibrary)int.Parse(context.CurrentCommand.Parameter);
        }

        public override void DisplayResponse(IGameContext context)
        {
            Console.WriteLine("You choose: {0}", context.Game.Name);
        }

    }
}
