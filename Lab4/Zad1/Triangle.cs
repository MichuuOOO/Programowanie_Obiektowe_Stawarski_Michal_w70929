namespace Zad1
{
    public class Triangle(double x, double y, double height, double width) : Shape(x, y, height, width)
    {
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Rysujemy trójkąt o współrzędnych: {X}, {Y} o wysokości {Height} i długości {Width}");
        }
    }

}
