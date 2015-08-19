using System;

namespace Storybox.Cli
{
    sealed class HardcodedEnglishResourceDictionary : ResourceDictionary
    {
        public string SelectGame { get; } = "Please type the game you want to play:";

        public string GameSelected(string gameName)
            => $"You chose: {gameName}";
    }
}
