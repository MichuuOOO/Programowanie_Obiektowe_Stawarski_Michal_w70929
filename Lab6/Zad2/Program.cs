class Program
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku ktory chcesz odczytac: ");
        string fileName = Console.ReadLine();  

        if (File.Exists(fileName))  
        {
            try
            {
                string zawartosc = File.ReadAllText(fileName);  
                Console.WriteLine("Zawartość pliku:");
                Console.WriteLine(zawartosc);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd odczytu pliku: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Plik nie istnieje.");
        }
    }
}
