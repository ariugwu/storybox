using System;

namespace Storybox.Cli
{
    using Core;
    using Core.Interpreter;
    using Core.Loader;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GameContext();

            Console.WriteLine("Please type the game you want to play:");
            Console.Write(">");

            context.UserInput = Console.ReadLine();

            context.Interpreter = new GameSelectionInterpreter(); //TODO: A smarter way to know what interpreter to use.

            context.Interpreter.Interpret(context);

            context.Game = GameFactory.Create(context.GameLibraryItem);

            Console.WriteLine("You chose: {0}", context.Game.Name);

            Console.ReadKey();
        }
    }
}
