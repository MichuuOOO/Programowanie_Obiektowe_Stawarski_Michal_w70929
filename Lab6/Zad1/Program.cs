class Program
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku: ");
        string fileName = Console.ReadLine();

        Console.Write("Podaj swój numer albumu: ");
        string numerAlbumu = Console.ReadLine();  

        try
        {
            File.WriteAllText(fileName, numerAlbumu);
            Console.WriteLine($"Numer albumu zapisano do pliku {fileName}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Wystąpił błąd: {e.Message}");
        }
    }
}
