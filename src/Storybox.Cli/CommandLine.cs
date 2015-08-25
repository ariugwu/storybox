using System.Collections.Generic;

namespace Storybox.Cli
{
    interface CommandLine
    {
        void Display(string resource);
        string RequestInput();
        void WaitToExit();
    }
}
