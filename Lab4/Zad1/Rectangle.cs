namespace Zad1
{
    internal class Rectangle(double x, double y, double height, double width) : Shape(x, y, height, width)
    {
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Rysujemy prostokąt o współrzędnych: {X}, {Y} o wysokości {Height} i długości {Width}");
        }
    }

}
