using System;

class Zad1
{
    static void Main()
    {
        zadanie1();
    }

    static void zadanie1()
    {
        double a = DoubleInput();
        double b = DoubleInput();
        double c = DoubleInput();

        double delta, x1, x2;

        if (a == 0)
        {
            Console.WriteLine("To nie jest równanie kwadratowe!");
        }
        else
        {
            delta = (Math.Pow(b, 2)) - (4 * a * c);
            if (delta < 0)
            {
                Console.WriteLine("Brak rozwiązań.");
            }
            else if (delta > 0)
            {
                x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"Są dwa rozwiązania: x1 = {x1}, x2 = {x2}");
            }
            else
            {
                x1 = -b / (2 * a);
                Console.WriteLine($"Jest jedno rozwiązanie: x1 = {x1}");
            }
        }
    }

    static double DoubleInput()
    {
        double value;
        while (true)
        {
            Console.WriteLine("Podaj liczbę: ");
            if (double.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Podaj inne liczby");
            }
        }
    }
}
