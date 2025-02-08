using System.Text.Json;

class Program
{
    static void Main()
    {
        string filePath = "db.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Plik db.json nie istnieje!");
            return;
        }

        List<PopulationData> data;
        try
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonSerializer.Deserialize<List<PopulationData>>(jsonContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd wczytywania pliku JSON: {ex.Message}");
            return;
        }

        Console.WriteLine("Plik załadowany poprawnie!\n");

        Console.WriteLine("Różnica populacji pomiędzy rokiem 1970 a 2000 dla Indii(IN): " + GetDifference(data, "IN", 1970, 2000));
        Console.WriteLine("Różnica populacji pomiędzy rokiem 1965 a 2010 dla USA(US): " + GetDifference(data, "US", 1965, 2010));
        Console.WriteLine("Różnica populacji pomiędzy rokiem 1980 a 2018 dla Chin(CN): " + GetDifference(data, "CN", 1980, 2018));

        Console.Write("\nPodaj kod kraju (IN, US, CN): ");
        string country = Console.ReadLine().ToUpper();

        Console.Write("Podaj rok, dla którego chcesz wyświetlić populacje: ");
        int year = int.Parse(Console.ReadLine());

        long? population = GetPopulation(data, country, year);
        if (population != null)
            Console.WriteLine($"Populacja {country} w {year}: {population}");
        else
            Console.WriteLine("Brak danych dla tego roku.");
        Console.WriteLine($"\nSprawdzenie różnicy populacji dla {country}");
        Console.Write("\nPodaj pierwszy rok do porównania: ");
        int year1 = int.Parse(Console.ReadLine());

        Console.Write("Podaj drugi rok do porównania: ");
        int year2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"Różnica populacji między {year1} a {year2}: {GetDifference(data, country, year1, year2)}");

        Console.Write("\nPodaj rok, dla którego chcesz sprawdzić wzrost populacji: ");
        int endYear = int.Parse(Console.ReadLine());

        double? growth = GetYearlyPopulationGrowth(data, country, endYear);
        if (growth != null)
            Console.WriteLine($"Procentowy wzrost populacji dla {country} w {endYear} względem {endYear - 1}: {growth:F2}%");
        else
            Console.WriteLine("Brak danych dla podanego roku lub poprzedniego.");

        Console.WriteLine("\nKoniec programu.");
    }

    static long? GetPopulation(List<PopulationData> data, string countryCode, int year)
    {
        var record = data.FirstOrDefault(p => p.Country.Code == countryCode && p.Year == year);
        return record?.Population;
    }

    static long GetDifference(List<PopulationData> data, string countryCode, int year1, int year2)
    {
        long? pop1 = GetPopulation(data, countryCode, year1);
        long? pop2 = GetPopulation(data, countryCode, year2);

        if (pop1 == null || pop2 == null)
            return 0;

        return pop2.Value - pop1.Value;
    }

    static double? GetYearlyPopulationGrowth(List<PopulationData> data, string countryCode, int year)
    {
        long? popCurrent = GetPopulation(data, countryCode, year);
        long? popPrevious = GetPopulation(data, countryCode, year - 1);

        if (popCurrent == null || popPrevious == null || popPrevious == 0)
            return null;

        return ((double)(popCurrent - popPrevious) / popPrevious) * 100;
    }
}
