using Zad2_3.Interfejsy;

namespace Zad2_3.Klasy
{
    public class Student : Osoba, IStudent
    {
        public required string Uczelnia { get; set; }
        public required string Kierunek { get; set; }
        public int Rok { get; set; }
        public int Semestr { get; set; }

        public string WypiszPelnaNazweIUczelnie()
        {
            return $"{ZwrocPelnaNazwe()} - {Kierunek} {Rok} rok, {Semestr} semestr ({Uczelnia})";
        }
    }
}
