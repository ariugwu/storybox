using System;

namespace Storybox.Cli.EntityComponentSystem
{
	static class EntityComponentExtensions
	{
		public static EntityComponentTracker Tracker { get; set; }

		internal static void Assign(this object entity, object component)
		{
			if (Tracker == null)
				throw new NotInitialisedException();
			Tracker.Assign(entity, component);
		}
	}
}
