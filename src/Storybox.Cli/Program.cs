using System;
using Storybox.Core;
using Storybox.Core.Interpreter;
using Storybox.Core.Loader;

namespace Storybox.Cli
{

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GameContext();

            Console.WriteLine("Please input player name:"); // Display for the current state.
            Console.Write(">"); // Prompt

            context.UserInput = Console.ReadLine(); // User Input

            context.Interpret(); // Interpret UserInput

            Console.WriteLine("Welcome {0}!", context.Player); // Display output of interpretation

            Console.WriteLine();

            Console.WriteLine("1. Bubble Commander");
            Console.WriteLine("2. Syn");
            Console.WriteLine("Please type the game you want to play:");
            Console.Write(">");

            context.UserInput = Console.ReadLine();

            context.Interpret(); //TODO: How do we actually change the interpreter

            context.Game = GameFactory.Create(context.GameLibraryItem);

            Console.WriteLine("You choose: {0}", context.Game.Name);

            Console.WriteLine("Please input a command:");
            Console.Write(">");

            context.UserInput = Console.ReadLine();

            context.Interpret();

            Console.WriteLine();

            Console.ReadKey();

        }

    }
}
