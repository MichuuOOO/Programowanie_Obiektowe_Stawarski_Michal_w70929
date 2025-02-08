namespace Zad1
{
    public class Shape(double x, double y, double height, double width)
    {
        public double X { get; set; } = x;
        public double Y { get; set; } = y;
        public double Height { get; set; } = height;
        public double Width { get; set; } = width;

        public virtual void Draw()
        {
            Console.WriteLine("\nRysujemy figurę");
        }
    }
}
