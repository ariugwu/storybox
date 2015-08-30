namespace Storybox.Cli
{
	interface EntityComponentTracker
	{
		void Assign<T>(object entity, T component);

		T Fetch<T>(object entity);
	}
}
