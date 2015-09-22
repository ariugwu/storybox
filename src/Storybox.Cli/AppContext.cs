using System;
using Storybox.Core;
using Storybox.Core.Game.Handler;

namespace Storybox.Cli
{
    public class AppContext
    {
        public AppContext()
        {
            _gameContext.SetGameSelectionHandler(new GameSelectionHandler());
            _appState = AppState.Stopped;
        }

        private AppState _appState { get; set; }

        private GameContext _gameContext = new GameContext();

        private void GameStart()
        {
            _appState = AppState.Running;
            _gameContext.Start();
        }

        public void Start()
        {
            GameStart();
        }

        public void Stop()
        {
            if (_appState != AppState.Running)
            {
                Console.WriteLine("Application is not in a running state.");
            }
        }
    }
}
