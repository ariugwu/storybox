﻿using Storybox.Common;
using Storybox.Common.Game;

namespace Storybox.Core.Game.Handler
{
    public class PlayerLoadHandler : Common.Game.GameHandler
    {
        public override void HandleRequest(IGameContext gameContext)
        {
            if (!string.IsNullOrWhiteSpace(gameContext.Player))
            {
                gameContext.GameStateType = GameStateType.GameSelection;
            }
        }
    }
}
