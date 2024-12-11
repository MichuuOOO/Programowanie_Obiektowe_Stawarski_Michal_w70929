using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj ilość liczb, które chcesz wprowadzić?");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] liczby = new int[n];

        Console.WriteLine("Podaj liczby:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Liczba {i + 1}: ");
            liczby[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 1; i < liczby.Length; i++)
        {
            int klucz = liczby[i];
            int j = i - 1;

            while (j >= 0 && liczby[j] > klucz)
            {
                liczby[j + 1] = liczby[j];
                j--;
            }
            liczby[j + 1] = klucz;
        }

        Console.WriteLine("Twoje posortowane liczby:");
        foreach (int liczba in liczby)
        {
            Console.WriteLine(liczba);
        }
    }
}