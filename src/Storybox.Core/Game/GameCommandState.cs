using System;
using Storybox.Common;
using Storybox.Common.Game;
using Storybox.Core.Domain.Interpreter;

namespace Storybox.Core.Game
{
    public class GameCommandState : GameState
    {
        public GameCommandState() : base(new CommandInterpreter())
        {
        }

        public override void DisplayPrompt(IGameContext context)
        {
            Console.WriteLine("Please input a command:");
            Console.Write(">");
        }

        public override void Interpret(IGameContext context)
        {
            throw new NotImplementedException();
        }

        public override void DisplayResponse(IGameContext context)
        {
            throw new NotImplementedException();
        }

    }
}
