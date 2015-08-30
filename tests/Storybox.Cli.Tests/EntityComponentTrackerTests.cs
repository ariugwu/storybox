using FluentAssertions;
using System;
using TestAttributes;

namespace Storybox.Cli.Tests
{
	public class EntityComponentTrackerTests
	{
		static EntityComponentTracker CreateTarget()
		{
			return new InMemoryEntityComponentStateManager();
		}

		[Unit]
		public static void WhenAssigningToEntityThatIsNullThenThrowsException()
		{
			Action act = () => CreateTarget().Assign(null, new object());
			act.ShouldThrow<ArgumentNullException>();
		}

		[Unit]
		public static void WhenAssignedComponentIsNullThenThrowsException()
		{
			Action act = () => CreateTarget().Assign(new object(), (object)null);
			act.ShouldThrow<ArgumentNullException>();
		}

		[Unit]
		public static void WhenFetchingFromEntityThatIsNullThenThrowsException()
		{
			Action act = () => CreateTarget().Fetch<object>(null);
			act.ShouldThrow<ArgumentNullException>();
		}

		[Unit]
		public static void WhenFetchingAssignedComponentThenAssignedComponentIsReturned()
		{
			var entity = new object();
			var component = new object();
			var target = CreateTarget();

			target.Assign(entity, component);

			target.Fetch<object>(entity)
				.Should().Be(component);
		}

		[Unit]
		public static void WhenMultipleComponentsAssignedThenAnyComponentCanBeRetrieved()
		{
			var entity = new object();
			var componentA = 1;
			var componentB = "1";
			var target = CreateTarget();

			target.Assign(entity, componentA);
			target.Assign(entity, componentB);

			target.Fetch<int>(entity)
				.Should().Be(componentA);
		}
	}
}
