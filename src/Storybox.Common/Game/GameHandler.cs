using System;

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

            gameContext.UserInput = Console.ReadLine();

            gameContext.GameState.Interpret(gameContext);

            gameContext.GameState.DisplayResponse(gameContext);

            gameContext.GameState.UnloadState(gameContext);

            successor.Process(gameContext);
        }

        public abstract void HandleRequest(IGameContext gameContext);
    }
}
