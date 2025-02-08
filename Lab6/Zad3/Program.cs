class Program
{
    static void Main()
    {
        string fileName = "pesels.txt";  

        if (!File.Exists(fileName))  
        {
            Console.WriteLine("Plik pesels.txt nie istnieje!");
            return;
        }

        try
        {
            string[] pesels = File.ReadAllLines(fileName);  
            int liczbaKobiet = pesels.Count(pesel => pesel.Length == 11 && pesel[9] % 2 == 0);

            Console.WriteLine($"Liczba kobiet: {liczbaKobiet}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd odczytu pliku: {e.Message}");
        }
    }
}
