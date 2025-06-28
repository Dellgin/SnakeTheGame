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