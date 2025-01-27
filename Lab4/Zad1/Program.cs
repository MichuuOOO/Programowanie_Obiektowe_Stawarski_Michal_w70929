using Zad1;
class Program
{
    static void Main()
    {
        List<Shape> shapes =
        [
            new Rectangle(),
            new Triangle(),
            new Circle()
        ];

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
