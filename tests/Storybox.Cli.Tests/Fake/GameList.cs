using Storybox.Core;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;

namespace Storybox.Cli.Tests.Fake
{
    sealed class GameList : IEnumerable<Game>
    {
        private IEnumerable<Game> _internal;
        public GameList(params string[] gameNames)
        {
            _internal = gameNames.Select(x => new Game(x));
        }

        public IEnumerator<Game> GetEnumerator()
            => _internal.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _internal.GetEnumerator();
    }
}
