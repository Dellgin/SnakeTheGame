public static class Game
{
    private static int _width = 48;
    private static int _height = 24;

    public static void Run()
    {
        Console.CursorVisible = false;
        Console.Clear();
        RenderField();
    }

    private static void RenderField()
    {
        Console.WriteLine(new string('#', _width));
        for (int i = 1; i < _height - 1; i++)
        {
            Console.WriteLine($"#{new string(' ', _width - 2)}#");
        }
        Console.WriteLine(new string('#', _width));
    }
}