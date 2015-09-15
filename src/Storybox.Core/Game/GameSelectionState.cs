using System;
using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Core.Interpreter;
using Storybox.Core.Loader;

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

        public override void Interpret(IGameContext context)
        {
            context.GameStateType = GameStateType.GameSelection;
            Interpreter.Interpret(context);
            context.Game = GameFactory.Create(context.GameLibraryItem);
        }

        public override void DisplayResponse(IGameContext context)
        {
            Console.WriteLine("You choose: {0}", context.Game.Name);
        }

    }
}
