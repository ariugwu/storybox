namespace Storybox.Cli
{
    interface ResourceDictionary
    {
        string SelectGame { get; }
        string GameSelected(string gameName);
    }
}
