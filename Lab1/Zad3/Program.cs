using System;

class Program
{
    static void Main()
    {
        double[] liczby = new double[10];
        Console.WriteLine("Wprowadź 10 liczb rzeczywistych:");
        for (int i = 0; i < liczby.Length; i++)
        {
            Console.Write($"Podaj liczbę {i + 1}: ");
            liczby[i] = Convert.ToDouble(Console.ReadLine());
        }

        bool dalej = true;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Wyświetl tablicę od pierwszego do ostatniego indeksu.");
            Console.WriteLine("2. Wyświetl tablicę od ostatniego do pierwszego indeksu.");
            Console.WriteLine("3. Wyświetl elementy o nieparzystych indeksach.");
            Console.WriteLine("4. Wyświetl elementy o parzystych indeksach.");
            Console.WriteLine("0. Wyjście.");
            Console.Write("Wybierz opcję: ");
            int wybor = Convert.ToInt32(Console.ReadLine());

            if (wybor == 1)
            {
                Console.WriteLine("Tablica od pierwszego do ostatniego indeksu:");
                for (int i = 0; i < liczby.Length; i++)
                {
                    Console.WriteLine($"Indeks {i}: {liczby[i]}");
                }
            }
            else if (wybor == 2)
            {
                Console.WriteLine("Tablica od ostatniego do pierwszego indeksu:");
                for (int i = liczby.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine($"Indeks {i}: {liczby[i]}");
                }
            }
            else if (wybor == 3)
            {
                Console.WriteLine("Elementy o nieparzystych indeksach:");
                for (int i = 1; i < liczby.Length; i += 2)
                {
                    Console.WriteLine($"Indeks {i}: {liczby[i]}");
                }
            }
            else if (wybor == 4)
            {
                Console.WriteLine("Elementy o parzystych indeksach:");
                for (int i = 0; i < liczby.Length; i += 2)
                {
                    Console.WriteLine($"Indeks {i}: {liczby[i]}");
                }
            }
            else if (wybor == 0)
            {
                dalej = false;
                Console.WriteLine("Do widzenia!");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            }

        } while (dalej);
    }
}