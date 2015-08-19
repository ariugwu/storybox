using Storybox.Core;
using System;
using System.Collections.Generic;

namespace Storybox.Cli
{
    sealed class SelectGame
    {
        private readonly CommandLine _commandLine;
        private readonly ResourceDictionary _dictionary;
        private readonly GameFactory _gameFactory;

        public SelectGame(CommandLine commandLine, ResourceDictionary dictionary, GameFactory gameFactory)
        {
            if (commandLine == null)
                throw new ArgumentNullException(nameof(commandLine));
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            if (gameFactory == null)
                throw new ArgumentNullException(nameof(gameFactory));
            _commandLine = commandLine;
            _dictionary = dictionary;
            _gameFactory = gameFactory;
        }

        public void Execute()
        {
            _commandLine.Display(_dictionary.SelectGame);
            var game = _gameFactory.Resolve(_commandLine.RequestInput());
            _commandLine.Display(_dictionary.GameSelected(game?.Name));
            _commandLine.WaitToExit();
        }
    }
}
