using System;
using Storybox.Core.Domain;
using Storybox.Core.Domain.Interpreter;
using Storybox.Core.Domain.Loader;

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

            context.Interpreter = new PlayerInterpreter(); // Load Interpreter

            context.Interpreter.Interpret(context); // Interpret UserInput

            Console.WriteLine("Welcome {0}!", context.Player); // Display output of interpretation

            Console.WriteLine();


            Console.WriteLine("1. Bubble Commander");
            Console.WriteLine("2. Syn");
            Console.WriteLine("Please type the game you want to play:");
            Console.Write(">");

            context.UserInput = Console.ReadLine();

            context.Interpreter = new GameSelectionInterpreter(); //TODO: A smarter way to know what interpreter to use.

            context.Interpreter.Interpret(context);

            context.Game = GameFactory.Create(context.GameLibraryItem);

            Console.WriteLine("You choose: {0}", context.Game.Name);

            Console.WriteLine("Please input a command:");
            Console.Write(">");

            context.UserInput = Console.ReadLine();

            context.Interpreter = new CommandInterpreter();

            context.Interpreter.Interpret(context);

            Console.WriteLine();

            Console.ReadKey();

        }

    }
}
