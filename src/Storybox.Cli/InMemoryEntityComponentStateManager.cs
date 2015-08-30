using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Storybox.Cli
{
	sealed class InMemoryEntityComponentStateManager : EntityComponentTracker
	{
		 ConcurrentDictionary<object, ConcurrentDictionary<Type, object>> _state = 
			new ConcurrentDictionary<object, ConcurrentDictionary<Type, object>>();

		public void Assign<T>(object entity, T component)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));
			if (component == null)
				throw new ArgumentNullException(nameof(component));
			// TODO : Consider Danjeeeee's and Stu's idea for typed state
			var componentDictionary = _state.GetOrAdd(entity, e => new ConcurrentDictionary<Type, object>());
			componentDictionary.TryAdd(component.GetType(), component);
		}

		public T Fetch<T>(object entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));
			ConcurrentDictionary<Type, object> componentDictionary;
			object value;
			if (_state.TryGetValue(entity, out componentDictionary))
				if (componentDictionary.TryGetValue(typeof(T), out value))
					return (T)value;
			return default(T);
		}
	}
}
