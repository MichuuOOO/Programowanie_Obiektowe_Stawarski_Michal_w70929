using System; 
class zad1
{
    static void Main()
    {
        Console.WriteLine("Program obliczający deltę i pierwiastki równania kwadratowego(a,b,c).");
        Console.Write("Podaj współczynnik a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj współczynnik b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj współczynnik c: ");
        double c = Convert.ToDouble(Console.ReadLine());
        double delta = b * b - 4 * a * c;
        Console.WriteLine($"\nDelta wynosi: {delta}");
        if (delta >= 0)
        {
            double sqrtDelta = Math.Sqrt(delta);
            double x1 = (-b + sqrtDelta) / (2 * a);
            double x2 = (-b - sqrtDelta) / (2 * a);

            if (delta > 0)
                Console.WriteLine($"Równanie ma dwa pierwiastki rzeczywiste: x1 = {x1}, x2 = {x2}");
            else
                Console.WriteLine($"Równanie ma jeden pierwiastek: x0 = {x1}");
        }
        else
        {
            Console.WriteLine("Równanie nie ma pierwiastków rzeczywistych.");
        }
    }
}