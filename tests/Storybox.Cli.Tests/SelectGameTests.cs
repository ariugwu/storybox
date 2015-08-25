using FluentAssertions;
using Moq;
using Storybox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAttributes;

namespace Storybox.Cli.Tests
{
    public class SelectGameTests
    {
        static CommandLine DefaultCommandLine
        {
            get
            {
                return new Mock<CommandLine>().Object;
            }
        }

        static ResourceDictionary DefaultDictionary
        {
            get
            {
                return new Mock<ResourceDictionary>().Object;
            }
        }

        static GameFactory DefaultGameFactory
        {
            get
            {
                return new Mock<GameFactory>().Object;
            }
        }

        public class Constructor
        {

            [Unit]
            public static void WhenCommandLineIsNullThenThrowsException()
            {
                Action act = () => new SelectGame(null, DefaultDictionary, DefaultGameFactory);
                act.ShouldThrow<ArgumentNullException>();
            }

            [Unit]
            public static void WhenDictionaryIsNullThenThrowsException()
            {
                Action act = () => new SelectGame(DefaultCommandLine, null, DefaultGameFactory);
                act.ShouldThrow<ArgumentNullException>();
            }

            [Unit]
            public static void WhenGameFactoryIsNullThenThrowsException()
            {
                Action act = () => new SelectGame(DefaultCommandLine, DefaultDictionary, null);
                act.ShouldThrow<ArgumentNullException>();
            }
        }

        public class Execute
        {
            static string RandomString
            {
                get
                {
                    return Guid.NewGuid().ToString();
                }
            }

            static SelectGame CreateTarget(
                CommandLine commandLine = null,
                ResourceDictionary dictionary = null,
                GameFactory gameFactory = null)
            {
                return new SelectGame(
                    commandLine ?? DefaultCommandLine,
                    dictionary ?? DefaultDictionary,
                    gameFactory ?? DefaultGameFactory);
            }

            [Unit]
            public static void WhenExecutedThenDisplaysGameSelectionResource()
            {
                var commandLine = new Mock<CommandLine>();
                var dictionary = new Mock<ResourceDictionary>();
                var resource = RandomString;
                dictionary.SetupGet(m => m.SelectGame).Returns(resource);

                CreateTarget(commandLine: commandLine.Object, dictionary: dictionary.Object).Execute();

                commandLine.Verify(m => m.Display(resource), Times.Once);
            }

            [Unit]
            public static void WhenGameSelectionDisplayedThenRequestsGameSelectionInput()
            {
                var dictionary = new Mock<ResourceDictionary>();
                var commandLine = new Mock<CommandLine>();
                dictionary
                    .SetupGet(m => m.SelectGame)
                    .Callback(() => commandLine.Verify(m => m.RequestInput(), Times.Never));

                CreateTarget(commandLine: commandLine.Object, dictionary: dictionary.Object).Execute();

                commandLine.Verify(m => m.RequestInput(), Times.Once);
            }

            [Unit]
            public static void WhenInputReceivedThenRequestsGameFromFactory()
            {
                var commandLine = new Mock<CommandLine>();
                var gameFactory = new Mock<GameFactory>();
                var input = RandomString;
                commandLine
                    .Setup(m => m.RequestInput())
                    .Callback(() => gameFactory.Verify(m => m.Resolve(It.IsAny<string>()), Times.Never))
                    .Returns(input);

                CreateTarget(commandLine: commandLine.Object, gameFactory: gameFactory.Object).Execute();

                gameFactory.Verify(m => m.Resolve(input), Times.Once);
            }

            [Unit]
            public static void WhenGameResolvedThenRequestsGameChosenResourceForGame()
            {
                var gameFactory = new Mock<GameFactory>();
                var dictionary = new Mock<ResourceDictionary>();
                var game = new Fake.Game(RandomString);
                gameFactory
                    .Setup(m => m.Resolve(It.IsAny<string>()))
                    .Callback(() => dictionary.Verify(m => m.GameSelected(It.IsAny<string>()), Times.Never))
                    .Returns(game);

                CreateTarget(dictionary: dictionary.Object, gameFactory: gameFactory.Object).Execute();

                dictionary.Verify(m => m.GameSelected(game.Name), Times.Once);
            }

            [Unit]
            public static void WhenResolvedGameChosenResourceThenDisplaysResource()
            {
                var commandLine = new Mock<CommandLine>();
                var resource = RandomString;
                var dictionary = new Mock<ResourceDictionary>();
                dictionary
                    .Setup(m => m.GameSelected(It.IsAny<string>()))
                    .Callback(() => commandLine.Verify(m => m.Display(It.IsAny<string>()), Times.Once))
                    .Returns(resource);

                CreateTarget(commandLine: commandLine.Object, dictionary: dictionary.Object).Execute();

                commandLine.Verify(m => m.Display(resource), Times.Once);
            }

            [Unit]
            public static void WhenGameChosenResourceDisplayedThenWaitsToExit()
            {
                var commandLine = new Mock<CommandLine>();
                commandLine
                    .Setup(m => m.Display(It.IsAny<string>()))
                    .Callback(() => commandLine.Verify(m => m.WaitToExit(), Times.Never));

                CreateTarget(commandLine: commandLine.Object).Execute();

                commandLine.Verify(m => m.WaitToExit(), Times.Once);
            }
        }
    }
}
