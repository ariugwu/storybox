using FluentAssertions;
using Storybox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAttributes;

namespace Storybox.Cli.Tests
{
    public class PreResolvedGameFactoryTests
    {
        static string RandomString
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }

        static IEnumerable<Game> DefaultGames
        {
            get
            {
                return Enumerable.Empty<Game>();
            }
        }

        static PreResolvedGameFactory CreateTarget(IEnumerable<Game> games = null)
        {
            return new PreResolvedGameFactory(games ?? DefaultGames);
        }

        [Unit]
        public static void WhenGameListIsNullThenThrowsException()
        {
            Action act = () => new PreResolvedGameFactory(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Unit]
        public static void WhenGameExistsAtIndexThenReturnsGame()
        {
            var game = new Fake.Game(RandomString);
            var games = new[] { game };

            CreateTarget(games).Resolve("0")
                .Should().Be(game);
        }

        [Unit]
        public static void WhenGameDoesNotExistThenThrowsException()
        {
            Action act = () => CreateTarget().Resolve(RandomString);
            act.ShouldThrow<ArgumentException>();
        }
    }
}
