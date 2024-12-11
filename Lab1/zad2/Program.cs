using System;

class Kalkulator
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nKalkulator - Wybierz operację:");
            Console.WriteLine("1. Suma (+)");
            Console.WriteLine("2. Różnica (-)");
            Console.WriteLine("3. Iloczyn (*)");
            Console.WriteLine("4. Iloraz (/)");
            Console.WriteLine("5. Potęgowanie (^)");
            Console.WriteLine("6. Pierwiastek (√)");
            Console.WriteLine("7. Sinus (sin)");
            Console.WriteLine("8. Cosinus (cos)");
            Console.WriteLine("9. Tangens (tan)");
            Console.WriteLine("0. Wyjście");

            Console.Write("Twój wybór: ");
            int wybor = Convert.ToInt32(Console.ReadLine());

            if (wybor == 0)
            {
                break;
            }

            Console.Write("Podaj pierwszą liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());

            double b = 0;
            if (wybor >= 1 && wybor <= 5)
            {
                Console.Write("Podaj drugą liczbę: ");
                b = Convert.ToDouble(Console.ReadLine());
            }

            switch (wybor)
            {
                case 1:
                    Console.WriteLine($"Wynik: {a} + {b} = {a + b}");
                    break;
                case 2:
                    Console.WriteLine($"Wynik: {a} - {b} = {a - b}");
                    break;
                case 3:
                    Console.WriteLine($"Wynik: {a} * {b} = {a * b}");
                    break;
                case 4:
                    Console.WriteLine(b != 0 ? $"Wynik: {a} / {b} = {a / b}" : "Nie można dzielić przez 0!");
                    break;
                case 5:
                    Console.WriteLine($"Wynik: {a}^{b} = {Math.Pow(a, b)}");
                    break;
                case 6:
                    Console.WriteLine(a >= 0 ? $"Wynik: √{a} = {Math.Sqrt(a)}" : "Pierwiastek z liczby ujemnej!");
                    break;
                case 7:
                    Console.WriteLine($"Wynik: sin({a}°) = {Math.Sin(Math.PI * a / 180)}");
                    break;
                case 8:
                    Console.WriteLine($"Wynik: cos({a}°) = {Math.Cos(Math.PI * a / 180)}");
                    break;
                case 9:
                    Console.WriteLine(Math.Cos(Math.PI * a / 180) != 0 ? $"Wynik: tan({a}°) = {Math.Tan(Math.PI * a / 180)}" : "Tangens niezdefiniowany!");
                    break;
                default:
                    Console.WriteLine("Wybierz operację, którą chcesz wykonać jeszcze raz.(0-9)");
                    break;
            }
        }
    }
}
