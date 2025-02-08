using System;
using System.Collections.Generic;
namespace Zad2;

class Program
{
    static void Main()
    {
        Dictionary<int, Order> zamowienia = new()
        {
            { 01, new Order(01, ["Mysz", "Klawiatura"], StatusZamowienia.Oczekujące) },
            { 02, new Order(02, ["Monitor", "Stolik"], StatusZamowienia.Przyjęte) },
            { 03, new Order(03, ["Laptop"], StatusZamowienia.Zrealizowane) }
        };

        bool koniec = false;
        while (!koniec)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Zmień status zamówienia");
            Console.WriteLine("2. Wyświetl wszystkie zamówienia");
            Console.WriteLine("3. Zakończ");
            Console.Write("Wybierz opcję (1-3): ");
            Console.WriteLine();

            string opcja = Console.ReadLine();
            switch (opcja)
            {
                case "1":
                    try
                    {
                        Console.Write("Podaj numer zamówienia: ");
                        int numerZamowienia = int.Parse(Console.ReadLine());

                        Console.WriteLine("Dostępne statusy:");
                        foreach (var status in Enum.GetValues(typeof(StatusZamowieni​a)))
                        {
                            Console.WriteLine($"{(int)status}. {status}");
                        }
                        Console.Write("Podaj nowy status (1-3): ");
                        int nowyStatusInt = int.Parse(s: Console.ReadLine());

                        if (!Enum.IsDefined(typeof(StatusZamowieni​a), nowyStatusInt))
                        {
                            Console.WriteLine("Nieprawidłowy wybór statusu.");
                            break;
                        }
                        StatusZamowieni​a nowyStatus = (StatusZamowieni​a)nowyStatusInt;

                        ZmienStatusZamowienia(zamowienia, numerZamowienia, nowyStatus);
                        Console.WriteLine("Sukces! Status zamówienia został zmieniony.");
                    }
                    catch (KeyNotFoundException ex)
                    {
                        Console.WriteLine($"Błąd: {ex.Message}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Błąd: {ex.Message}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Błąd: Nieprawidłowy format danych.");
                    }
                    break;

                case "2":
                    WyswietlZamowienia(zamowienia);
                    break;

                case "3":
                    koniec = true;
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Koniec programu.");
    }

    static void ZmienStatusZamowienia(Dictionary<int, Order> zamowienia, int numerZamowienia, StatusZamowieni​a nowyStatus)
    {
        if (!zamowienia.TryGetValue(numerZamowienia, out Order? value))
        {
            throw new KeyNotFoundException("Zamówienie o podanym numerze nie istnieje.");
        }

        Order zamowienie = value;
        if (zamowienie.Status == nowyStatus)
        {
            throw new ArgumentException("Nowy status jest taki sam jak obecny.");
        }

        zamowienie.Status = nowyStatus;
    }

    static void WyswietlZamowienia(Dictionary<int, Order> zamowienia)
    {
        Console.WriteLine("Lista zamówień:");
        foreach (var zamowienie in zamowienia.Values)
        {
            Console.WriteLine($"Zamówienie nr {zamowienie.OrderNumber}: Status = {zamowienie.Status}, Produkty = {string.Join(", ", zamowienie.Produkty)}");
        }
    }
}
