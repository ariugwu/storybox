using Compose;
using Storybox.Core;

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
