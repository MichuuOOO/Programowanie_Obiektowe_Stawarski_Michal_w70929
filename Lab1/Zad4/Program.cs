using System;

class Program
{
    static void Main()
    {
        double[] liczby = new double[10];
        Console.WriteLine("Podaj 10 liczb:");
        for (int i = 0; i < liczby.Length; i++)
        {
            Console.Write($"Podaj liczbę {i + 1}: ");
            liczby[i] = Convert.ToDouble(Console.ReadLine());
        }
        double suma = 0;
        double iloczyn = 1;
        double min = liczby[0];
        double max = liczby[0];

        foreach (double liczba in liczby)
        {
            suma += liczba;
            iloczyn *= liczba;
            if (liczba < min) min = liczba;
            if (liczba > max) max = liczba;
        }
        double srednia = suma / liczby.Length;

        Console.WriteLine("\nUzyskane wyniki:");
        Console.WriteLine($"Suma podanych liczb: {suma}");
        Console.WriteLine($"Iloczyn podanych liczb: {iloczyn}");
        Console.WriteLine($"Średnia wartość: {srednia}");
        Console.WriteLine($"Wartość minimalna: {min}");
        Console.WriteLine($"Wartość maksymalna: {max}");
    }
}