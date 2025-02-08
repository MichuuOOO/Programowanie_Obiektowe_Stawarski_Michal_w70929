using Zad1;
class Program
{
    static void Main()
    {
        List<Shape> shapes = [new Rectangle(11, 23, 20, 30), new Triangle(30, 40, 55, 75), new Circle(39, 69, 22)];

        foreach (Shape shape in shapes)
        {
            shape.Draw();
        }

    }
}
