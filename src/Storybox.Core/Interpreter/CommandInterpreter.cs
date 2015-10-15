using System;
using Storybox.Common;

namespace Storybox.Core.Domain.Interpreter
{
    using Storybox.Common.Interpreter;

    public class CommandInterpreter : Expression
    {
        public override void Interpret(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
