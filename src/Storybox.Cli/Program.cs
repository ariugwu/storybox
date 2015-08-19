using Compose;
using Storybox.Core;
using System;

namespace Storybox.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.UseServices(services =>
            {
                services
                    .AddCommandLine()
                    .AddCore();
            });
            app.UseCommandLineInterface();
            return app.Execute();
        }
    }
}
