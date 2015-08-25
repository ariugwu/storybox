using System;

namespace Storybox.Cli.Tests.Fake
{
    sealed class Game : Core.Game
    {
        public Game(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
