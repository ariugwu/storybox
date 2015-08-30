using System;

namespace Storybox.Cli.EntityComponentSystem
{
	static class EntityComponentExtensions
	{
		public static EntityComponentTracker Tracker { get; set; }

		internal static void Assign<T>(this object entity, T component)
		{
			if (Tracker == null)
				throw new NotInitialisedException();
			Tracker.Assign(entity, component);
		}

		internal static T Fetch<T>(this object entity)
		{
			if (Tracker == null)
				throw new NotInitialisedException();
			return Tracker.Fetch<T>(entity);
		}
	}
}
