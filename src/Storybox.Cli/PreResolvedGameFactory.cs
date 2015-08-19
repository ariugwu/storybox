using Storybox.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Storybox.Cli
{
    sealed class PreResolvedGameFactory : GameFactory
    {
        private readonly Dictionary<string, Game> _games;

        public PreResolvedGameFactory(IEnumerable<Game> games)
        {
            if (games == null)
                throw new ArgumentNullException(nameof(games));
            var index = 0;
            _games = games.ToDictionary(x => index++.ToString());
        }

        public Game Resolve(string gameName)
        {
            if (!_games.ContainsKey(gameName))
                throw new ArgumentException("Sorry, that game is not in the library!", nameof(gameName));
            return _games[gameName];
        }
    }
}
