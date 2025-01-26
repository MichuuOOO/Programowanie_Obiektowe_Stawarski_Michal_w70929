
namespace Zad3
{
    internal class Student
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        private List<int> Oceny { get; set; }

        public double SredniaOcen => Oceny.Count > 0 ? Oceny.Average() : 0;

        public Student(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Oceny = new List<int>();
        }

        public void DodajOcene(int ocena)
        {
            if (ocena < 1 || ocena > 6)
                throw new ArgumentException("Ocena musi być w zakresie od 1 do 6.");
            Oceny.Add(ocena);
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Imię: {Imie}, Nazwisko: {Nazwisko}, Średnia ocen: {SredniaOcen:F2}");
        }
    }
}

