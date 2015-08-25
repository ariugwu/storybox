using System;

namespace Storybox.Cli
{
    sealed class ConsoleCommandLine : CommandLine
    {
        public void Display(string resource)
        {
            Console.WriteLine(resource);
        }

        public void WaitToExit()
        {
            Console.ReadKey();
        }

        public string RequestInput()
        {
            Console.Write(">");
            return Console.ReadLine();
        }
    }
}
