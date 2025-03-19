using NUnit.Framework;

namespace CodeCraft
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod]
        public void TestDirectionAtStart()
        {
            var marsRover = new MarsRover(1, 1, Direction.North);
            NUnit.Framework.Assert.That(marsRover.Direction, Is.EqualTo(Direction.North));
        }

        [TestMethod]
        public void TestXPositionAtStart()
        {
            var marsRover = new MarsRover(1, 1, Direction.North);
            NUnit.Framework.Assert.That(marsRover.XPosition, Is.EqualTo(1));
        }

        [TestMethod]
        public void TestYPositionAtStart()
        {
            var marsRover = new MarsRover(1, 2, Direction.North);
            NUnit.Framework.Assert.That(marsRover.YPosition, Is.EqualTo(2));
        }

        [TestMethod]
        public void TestRightTurnAtStart()
        {
            List<string> moves = ["R"];
            var marsRover = new MarsRover(1, 1, Direction.North);
            marsRover.ProcessMoves(moves);
            NUnit.Framework.Assert.That(marsRover.Direction, Is.EqualTo(Direction.East));
        }

        [TestMethod]
        public void TestLeftTurnAtStart()
        {
            List<string> moves = ["L"];
            var marsRover = new MarsRover(2, 2, Direction.North);
            marsRover.ProcessMoves(moves);
            NUnit.Framework.Assert.That(marsRover.Direction, Is.EqualTo(Direction.West));
        }

        [TestMethod]
        public void TestMoveForwardAtStart()
        {
            List<string> moves = ["F"];
            var marsRover = new MarsRover(1, 1, Direction.North);
            marsRover.ProcessMoves(moves);
            NUnit.Framework.Assert.That(marsRover.YPosition, Is.EqualTo(2));
        }

        [TestMethod]
        public void TestMoveBackwardAtStart()
        {
            List<string> moves = ["B"];
            var marsRover = new MarsRover(2, 2, Direction.North);
            marsRover.ProcessMoves(moves);
            NUnit.Framework.Assert.That(marsRover.YPosition, Is.EqualTo(1));
        }

        [TestMethod]
        public void TestMultipleMoves()
        {
            List<string> moves = ["F", "B"];
            var marsRover = new MarsRover(2, 2, Direction.North);
            marsRover.ProcessMoves(moves);
            NUnit.Framework.Assert.That(marsRover.YPosition, Is.EqualTo(2));
        }

        [TestMethod]
        public void TestMultipleMovesWithInvalidItem()
        {
            List<string> moves = ["F", "Z", "B"];
            var marsRover = new MarsRover(2, 2, Direction.North);
            marsRover.ProcessMoves(moves);
            NUnit.Framework.Assert.That(marsRover.YPosition, Is.EqualTo(2));
        }
    }
}


