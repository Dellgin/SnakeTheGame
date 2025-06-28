public static class Game
{
    private static int _width = 48;
    private static int _height = 24;
    private static Snake _snake = new(new(22, 12));
    private static Food _food = new(_snake);

    public static void Run()
    {
        Console.CursorVisible = false;
        _food.Respawn();
        while (true)
        {
            Console.Clear();
            RenderField();
            _snake.Draw();
            _food.Draw();

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow: _snake.ChangeDirection(Direction.up); break;
                    case ConsoleKey.DownArrow: _snake.ChangeDirection(Direction.down); break;
                    case ConsoleKey.LeftArrow: _snake.ChangeDirection(Direction.left); break;
                    case ConsoleKey.RightArrow: _snake.ChangeDirection(Direction.right); break;
                }
            }

            _snake.Move();

            if (_snake.CheckSelfCollision()) return;
            if (_snake.CheckWallCollision(47, 24)) return;

            if (_snake.Head.Position.Equals(_food.Position))
            {
                _snake.Grow();
                _food.Respawn();
            }

            Thread.Sleep(500);
        }
    }

    private static void RenderField()
    {
        Console.WriteLine(new string('#', _width - 1));
        for (int i = 1; i < _height - 1; i++)
        {
            Console.WriteLine($"#{new string(' ', _width - 3)}#");
        }
        Console.WriteLine(new string('#', _width - 1));
    }
}