using FluentAssertions;
using Moq;
using Storybox.Cli.EntityComponentSystem;
using System;
using TestAttributes;

namespace Storybox.Cli.Tests
{
	public class EntityComponentSystemTests
	{
		public EntityComponentSystemTests()
		{
			EntityComponentExtensions.Tracker = null;
        }

		[Unit]
		public void WhenExtensionsAreNotInitialisedThenAssigningComponentThrowsException()
		{
			Action act = () => EntityComponentExtensions.Assign(new object(), new object());
			act.ShouldThrow<NotInitialisedException>();
		}

		[Unit]
		public void WhenExtensionsAreInitialisedThenAssignedComponentsArePassedThroughToStateManager()
		{
			var tracker = new Mock<EntityComponentTracker>();
            EntityComponentExtensions.Tracker = tracker.Object;
			var entity = new object();
			var component = new object();

			EntityComponentExtensions.Assign(entity, component);

			tracker.Verify(m => m.Assign(entity, component));
		}
	}
}
