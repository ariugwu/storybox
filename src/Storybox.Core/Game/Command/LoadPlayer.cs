using System;
using Storybox.Common;

namespace Storybox.Core.Game.Command
{
    public class LoadPlayer : Common.Command
    {
        public override void Execute(IGameContext context)
        {
            context.Player = context.CurrentCommand.Parameter;
        }
    }
}
