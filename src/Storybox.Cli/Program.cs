using System;
using Storybox.Core.Domain;
using Storybox.Core.Domain.Loader;

namespace Storybox.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GameContext();

            Console.WriteLine("Please type the game you want to play:");
            Console.Write(">");

            context.UserInput = Console.ReadLine();

            context.Interpreter = new Core.Domain.Interpreter.GameSelectionInterpreter(); //TODO: A smarter way to know what interpreter to use.

            context.Interpreter.Interpret(context);

            context.Game = GameFactory.Create(context.GameLibraryItem);

            Console.WriteLine("You choose: {0}", context.Game.Name);

            Console.ReadKey();
        }
    }
}
