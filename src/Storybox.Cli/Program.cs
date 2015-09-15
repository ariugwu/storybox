using System;
using Storybox.Core;

namespace Storybox.Cli
{

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GameContext();

            context.Process();

            Console.ReadKey();

        }

    }
}
