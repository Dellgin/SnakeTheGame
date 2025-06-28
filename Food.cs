public class Food
{
    Point position;

    public void Respawn()
    {
        position = new Point(new Random().Next(1, 23) * 2, new Random().Next(1, 23));
        Console.SetCursorPosition(position.X, position.Y);
        Console.Write("*");
    }
}