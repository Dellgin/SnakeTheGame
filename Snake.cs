public enum Direction { left, right, up, down };
public class Snake
{
    public SnakeSegment Head { get; private set; }
    public SnakeSegment Tail { get; private set; }
    private Direction _direction;

    public Snake(Point startPosition)
    {
        Head = new SnakeSegment(startPosition, isHead: true);
        Tail = Head;
        _direction = Direction.right;
    }

    public void Move()
    {
        Point headOldPosition = Head.Position;

        Head.Position = _direction switch
        {
            Direction.up => new Point(headOldPosition.X, headOldPosition.Y - 1),
            Direction.down => new Point(headOldPosition.X, headOldPosition.Y + 1),
            Direction.left => new Point(headOldPosition.X - 2, headOldPosition.Y),
            Direction.right => new Point(headOldPosition.X + 2, headOldPosition.Y),
            _ => throw new InvalidOperationException("Unknown direction")
        };

        SnakeSegment? current = Head.NextSegment;
        Point prevPosition = headOldPosition;

        while (current != null)
        {
            (prevPosition, current.Position) = (current.Position, prevPosition);
            current = current.NextSegment;
        }
    }

    public void Grow()
    {
        var newSegment = new SnakeSegment(Tail.Position);
        Tail.NextSegment = newSegment;
        Tail = newSegment;
    }

    public void ChangeDirection(Direction newDirection)
    {
        if ((_direction == Direction.left && newDirection == Direction.right) ||
            (_direction == Direction.right && newDirection == Direction.left) ||
            (_direction == Direction.up && newDirection == Direction.down) ||
            (_direction == Direction.down && newDirection == Direction.up))
        {
            return;
        }

        _direction = newDirection;
    }

    public bool CheckWallCollision(int w, int h) =>
        Head.Position.X < 1 || Head.Position.X > w - 1 ||
        Head.Position.Y < 1 || Head.Position.Y > h - 1;

    public bool CheckSelfCollision()
    {
        SnakeSegment? current = Head.NextSegment;
        while (current != null)
        {
            if (Head.Position.Equals(current.Position))
                return true;
            current = current.NextSegment;
        }
        return false;
    }

    public void Draw()
    {
        Console.SetCursorPosition(Head.Position.X, Head.Position.Y);
        Console.Write('@');

        SnakeSegment? current = Head.NextSegment;
        while (current != null)
        {
            Console.SetCursorPosition(current.Position.X, current.Position.Y);
            Console.Write('0');
            current = current.NextSegment;
        }
    }
}

public class SnakeSegment
{
    public Point Position { get; set; }
    public SnakeSegment? NextSegment { get; set; }

    public SnakeSegment(Point position, bool isHead = false)
    {
        Position = position;
        NextSegment = null;
    }
}