public class Food(Snake snake)
{
    public Point Position {  get; private set; }
    private readonly Snake snake = snake;

    public void Respawn()
    {
        bool validPosition;

        do
        {
            Position = new Point(new Random().Next(1, 23) * 2, new Random().Next(1, 23));

            validPosition = true;
            SnakeSegment? current = snake.Head;

            while (current != null)
            {
                if (current.Position.Equals(Position))
                {
                    validPosition = false;
                    break;
                }
                current = current.NextSegment;
            }
        } while (!validPosition);

        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write("*");
    }
}