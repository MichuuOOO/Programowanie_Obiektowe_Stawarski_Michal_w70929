using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Wprowadź liczby całkowite. Wprowadzenie liczby ujemnej zakończy program: ");

        for (; ; )
        {
            Console.Write("Podaj liczbę całkowitą: ");
            int liczba = Convert.ToInt32(Console.ReadLine());

            if (liczba < 0)
            {
                Console.WriteLine("Wprowadzono liczbę ujemną. Koniec programu.");
                break;
            }

            Console.WriteLine($"Wprowadzono liczbę: {liczba}");
        }
    }
}
