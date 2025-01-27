namespace Zad2_3.Klasy
{
    public class Nauczyciel : Osoba
    {
        public required string TytulNaukowy { get; set; }
        public List<Uczen> PodwladniUczniowie { get; set; } = [];

        public void WypiszUczniowMogacychWrocicSamodzielnie()
        {
            Console.WriteLine($"Uczniowie pod nadzorem {ZwrocPelnaNazwe()}, którzy mogą wrócić sami do domu:");
            foreach (var uczen in PodwladniUczniowie)
            {
                if (uczen.CanGoAloneToHome())
                {
                    Console.WriteLine($"- {uczen.ZwrocPelnaNazwe()}");
                }
            }
        }
    }
}
