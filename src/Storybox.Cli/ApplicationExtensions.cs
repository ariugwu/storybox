using Compose;

namespace Storybox.Cli
{
    static class ApplicationExtensions
    {
        public static void UseCommandLineInterface(this CommandLineApplication app)
        {
            app.OnExecute<SelectGame>(game =>
            {
                try
                {
                    game.Execute();
                    return 0;
                }
                catch
                {
                    return 1;
                }
            });
        }
    }
}
