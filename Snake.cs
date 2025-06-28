public enum Direction { left, right, up, down };
public class Snake
{
    public SnakeSegment Head { get; private set; }
    public SnakeSegment Tail { get; private set; }
    public Direction Direction { get; set; }

    public Snake(Point startPosition)
    {
        Head = new SnakeSegment(startPosition, isHead: true);
        Tail = Head;
        Direction = Direction.right;
    }

    public void Move()
    {
        Point headOldPosition = Head.Position;

        Head.Position = Direction switch
        {
            Direction.up => new Point(headOldPosition.X, headOldPosition.Y - 1),
            Direction.down => new Point(headOldPosition.X, headOldPosition.Y + 1),
            Direction.left => new Point(headOldPosition.X - 2, headOldPosition.Y),
            Direction.right => new Point(headOldPosition.X + 2, headOldPosition.Y),
            _ => throw new InvalidOperationException("Unknown direction")
        };

        SnakeSegment? current = Head.NextSegment;
        Point prevPosition = headOldPosition;

        if (current != null)
        {
            (prevPosition, current.Position) = (current.Position, prevPosition);
            current = current.NextSegment;
        }
    }

    public void Grow()
    {
        var newSegment = new SnakeSegment(Tail.Position);

        if (Head == Tail)
        {
            Head.NextSegment = newSegment;
        }
        else
        {
            SnakeSegment? current = Head;
            while (current!.NextSegment != Tail)
            {
                current = current.NextSegment;
            }
            current.NextSegment = newSegment;
        }

        Tail = newSegment;
    }
}

public class SnakeSegment
{
    public Point Position { get; set; }
    public bool IsHead { get; }
    public SnakeSegment? NextSegment { get; set; }

    public SnakeSegment(Point position, bool isHead = false)
    {
        Position = position;
        IsHead = isHead;
        NextSegment = null;
    }
}