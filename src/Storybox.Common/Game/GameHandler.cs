using System;
using Storybox.Common.Loader;

namespace Storybox.Common.Game
{
    public abstract class GameHandler
    {
        protected GameHandler successor;

        public void SetSuccessor(GameHandler successor)
        {
            this.successor = successor;
        }

        public void Process(IGameContext gameContext)
        {
            HandleRequest(gameContext);

            gameContext.GameState.LoadState(gameContext);

            gameContext.GameState.DisplayPrompt(gameContext);

            gameContext.CurrentCommand.UserInput = Console.ReadLine();

            gameContext.GameState.Interpret(gameContext.CurrentCommand); // TODO: Pick a better for this: 'InterpretUserInput'?

            gameContext.GameState.Process(gameContext); // TODO: Pick a better word for this: 'InitCommand'?

            gameContext.GameState.ExecuteCommand(gameContext);

            gameContext.GameState.DisplayResponse(gameContext);

            gameContext.GameState.UnloadState(gameContext);

            if (successor != null)
            {
                successor.Process(gameContext);
            }

            gameContext.CurrentCommand = null; // We're done with the command so blank it out. NOTE: This could be part of a 'Finalize' handler.
        }

        public abstract void HandleRequest(IGameContext gameContext);

        public void InitGame(IGame game)
        {
            // 1. Fetch Player Character
            game.LoadPlayer();
            // 2. Load game assets
            game.LoadAssets();
        }

        public void UnloadGame(IGame game)
        {
            // 1. Unload game
            game.Unload();
        }
    }
}
