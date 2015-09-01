using System;
using Storybox.Common.Loader;

namespace Storybox.Core.Loader
{
    using Storybox.Data.Loader;

    public class GameFactory
    {
        public static IGame Create(GameLibrary gameName)
        {
            switch (gameName)
            {
                case GameLibrary.Syn:
                    return new Syn { Name = "Syn: The Sci-Fi Adventure!"};
                case GameLibrary.BubbleCommander:
                    return new BubbleCommander(){Name = "Bubble Commander: The Last bubble!"};
                default:
                    throw new ArgumentException("Sorry that game is not in the library!");
            }
        }
    }
}
