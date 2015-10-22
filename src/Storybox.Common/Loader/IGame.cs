namespace Storybox.Common.Loader
{
    public interface IGame
    {
        string Name { get; set; }

        void LoadPlayer();

        void LoadAssets();

        void Unload();
    }
}
