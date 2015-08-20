using System;
using Storybox.Core.Domain.Loader;

namespace Storybox.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type the game you want to play:");
            Console.Write(">");

            var gameName = Console.ReadLine();

            var gameLibraryType = (GameLibrary) int.Parse(gameName);

            var game = GameFactory.Create(gameLibraryType);
            
            Console.WriteLine("You choose: {0}", game.Name);

            Console.ReadKey();
        }
    }
}
