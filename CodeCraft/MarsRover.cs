namespace CodeCraft
{
    public class MarsRover
    {
        private const string RIGHT = "R";
        private const string LEFT = "L";
        private const string FORWARD = "F";
        private const string BACKWARD = "B";

        private int xPosition;
        private int yPosition;
        private Direction direction;

        public int XPosition { get => xPosition; set => xPosition = value; }
        public int YPosition { get => yPosition; set => yPosition = value; }
        public Direction Direction { get => direction; set => direction = value; }

        public MarsRover(int x, int y, Direction direction)
        {
            XPosition = x;
            YPosition = y;
            this.Direction = direction;
        }

        private void ProcessInstruction(string moveType)
        {
            switch (moveType)
            {
                case RIGHT:
                    RotateRight();
                    break;
                case LEFT:
                    RotateLeft();
                    break;
                case FORWARD:
                    MoveForward();
                    break;
                case BACKWARD:
                    MoveBackward();
                    break;
            }
        }

        public void ProcessMoves(List<string> moves)
        {
            if (moves.Count > 0)
            {
                foreach (string move in moves)
                {
                    ProcessInstruction(move);
                }
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    YPosition += 1;
                    break;

                case Direction.East:
                    XPosition += 1;
                    break;
                case Direction.South:
                    YPosition -= 1;
                    break;
                case Direction.West:
                    XPosition -= 1;
                    break;
            }
        }

        private void MoveBackward()
        {
            switch (Direction)
            {
                case Direction.North:
                    YPosition -= 1;
                    break;

                case Direction.East:
                    XPosition -= 1;
                    break;
                case Direction.South:
                    YPosition += 1;
                    break;
                case Direction.West:
                    XPosition += 1;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
            }
        }
    }
}
