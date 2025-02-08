namespace Zad1
{
    internal class Circle(double x, double y, double radius) : Shape(x, y, radius, radius)
    {
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Rysujemy koło o współrzędnych: {X}, {Y} i promieniu r= {Width}");
        }
    }
}