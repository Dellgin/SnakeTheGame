public static class Game
{
    private static int _width = 48;
    private static int _height = 24;
    private static Food food = new();

    public static void Run()
    {
        Console.CursorVisible = false;
        Console.Clear();
        RenderField();
        food.Respawn();
        Console.ReadKey();
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