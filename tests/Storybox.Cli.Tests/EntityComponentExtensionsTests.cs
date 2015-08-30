using FluentAssertions;
using Moq;
using Storybox.Cli.EntityComponentSystem;
using System;
using TestAttributes;

namespace Storybox.Cli.Tests
{
	public class EntityComponentExtensionsTests
	{
		public EntityComponentExtensionsTests()
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

			entity.Assign(component);

			tracker.Verify(m => m.Assign(entity, component));
		}

		[Unit]
		public void WhenExtensionsAreNotInitialisedThenFetchingComponentThrowsException()
		{
			Action act = () => EntityComponentExtensions.Fetch<object>(new object());
			act.ShouldThrow<NotInitialisedException>();
		}

		[Unit]
		public void WhenExtensionsAreInitialisedThenFetchedComponentsAreRetrievedFromStateManager()
		{
			var tracker = new Mock<EntityComponentTracker>();
			EntityComponentExtensions.Tracker = tracker.Object;
			var entity = new object();

			entity.Fetch<object>();

			tracker.Verify(m => m.Fetch<object>(entity), Times.Once);
		}

		[Unit]
		public void WhenExtensionsAreInitialisedThenPassesFetchedComponentFromStateManager()
		{
			var tracker = new Mock<EntityComponentTracker>();
			EntityComponentExtensions.Tracker = tracker.Object;
			var entity = new object();
			var component = new object();
			tracker.Setup(m => m.Fetch<object>(entity)).Returns(component);

			entity.Fetch<object>()
				.Should().Be(component);
		}

		[Unit]
		public void WhenFetchingTypeOtherThanObjectThenRequestsSameTypeFromStateManager()
		{
			var tracker = new Mock<EntityComponentTracker>();
			EntityComponentExtensions.Tracker = tracker.Object;
			var entity = new object();

			entity.Fetch<int>();

			tracker.Verify(m => m.Fetch<int>(entity), Times.Once);
		}
	}
}
