using System;
using System.Collections.Generic;
using System.Drawing;

namespace Zad3
{
    class Program
    {
        static void Main()
        {
            List<Kolor> dostepneKolory = new()
            {
                Kolor.Czerwony,
                Kolor.Niebieski,
                Kolor.Zielony,
                Kolor.Żółty,
                Kolor.Fioletowy
            };

            Random rand = new();
            Kolor wybranyKolor = dostepneKolory[rand.Next(dostepneKolory.Count)];

            bool trafiono = false;
            Console.WriteLine("Gra w zgadywanie kolorów");
            Console.WriteLine("Dostępne kolory: Czerwony, Niebieski, Zielony, Żółty, Fioletowy");

            while (!trafiono)
            {
                Console.Write("Zgadnij kolor: ");
                string wpis = Console.ReadLine();

                try
                {
                    if (!Enum.TryParse<Kolor>(wpis, true, out Kolor zgadywanyKolor) ||
                        !dostepneKolory.Contains(zgadywanyKolor))
                    {
                        throw new ArgumentException("Wprowadzony kolor nie znajduje się na liście.");
                    }

                    if (zgadywanyKolor == wybranyKolor)
                    {
                        Console.WriteLine("Gratulacje! Zgadłes prawidłowy kolor.");
                        trafiono = true;
                    }
                    else
                    {
                        Console.WriteLine("Niestety, nie zgadles koloru. Spróbuj ponownie.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Błąd: {ex.Message}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Dzięki za grę!");
        }
    }
}
