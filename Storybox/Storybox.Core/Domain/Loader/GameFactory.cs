using System;
using Storybox.Common.Domain.Loader;
using Storybox.Data.Domain.Loader;

namespace Storybox.Core.Domain.Loader
{
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
