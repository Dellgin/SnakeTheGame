public class Food
{
    Point position;

    public void Respawn()
    {
        position = new Point() { 
            X = new Random().Next(1, 23) * 2,
            Y = new Random().Next(1, 23)
        };
        Console.SetCursorPosition(position.X, position.Y);
        Console.Write("*");
    }
}