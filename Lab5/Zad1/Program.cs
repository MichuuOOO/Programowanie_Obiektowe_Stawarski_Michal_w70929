enum Operacje
{
    Dodawanie,
    Odejmowanie,
    Mnozenie,
    Dzielenie
}
class Program
{
    static void Main()
    {
        List<double> historiaWynikow = [];

        try
        {
            Console.WriteLine("Podaj liczbe: ");
            double liczba1 = double.Parse(s: Console.ReadLine());

            Console.WriteLine("Podaj liczbe: ");
            double liczba2 = double.Parse(s: Console.ReadLine());

            Console.WriteLine("Wybierz opcje:\n");
            Console.WriteLine("0 - Dodawanie\n1 - Odejmowanie \n2 - Mnozenie\n3 - Dzielenie\n");

            Console.WriteLine("Twój wybor");
            int wyborOpcji = int.Parse(s: Console.ReadLine());
            Operacje operacja = (Operacje)wyborOpcji;

            double wynik = Oblicz(liczba1, liczba2, operacja);
            historiaWynikow.Add(wynik);
            Console.WriteLine($"Wynik operacji: {operacja}: {wynik}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Błąd! Wprowadzone dane nie są liczbami");
            Console.WriteLine($"Ślad stosu wywołań: \n{ex.StackTrace}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Błąd! Wybrano nieprawdidłową operacje");
            Console.WriteLine($"Ślad stosu wywołań:\n{ex.StackTrace}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd! Wybrano nieprawdidłową operacje");
            Console.WriteLine($"Ślad stosu wywołań:\n{ex.StackTrace}");
        }

        static double Oblicz(double liczba1, double liczba2, Operacje operacja)
        {
            switch (operacja)
            {
                case Operacje.Dodawanie:
                    return liczba1 + liczba2;
                case Operacje.Odejmowanie:
                    return liczba1 - liczba2;
                case Operacje.Mnozenie:
                    return liczba1 * liczba2;
                case Operacje.Dzielenie:
                    if (liczba2 == 0)
                        throw new DivideByZeroException("Dzielenie przez 0");
                    return liczba1 / liczba2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operacja), "Nieznana operacja");
            }
        }
    }
}