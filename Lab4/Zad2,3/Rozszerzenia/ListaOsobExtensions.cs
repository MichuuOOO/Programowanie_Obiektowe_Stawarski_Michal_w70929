using Zad2_3.Interfejsy;
using Zad2_3.Klasy;

namespace Zad2_3.Rozszerzenia
{
    public static class ListaOsobExtensions
    {
        public static void WypiszOsoby(this List<IOsoba> osoby)
        {
            foreach (var osoba in osoby)
            {
                Console.WriteLine(osoba.ZwrocPelnaNazwe());
            }
        }

        public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
        {
            osoby.Sort((o1, o2) => o1.Nazwisko.CompareTo(o2.Nazwisko));
        }

        public static void WypiszPelneNazwyIUczelnie(this List<StudentWSIiZ> studenci)
        {
            foreach (var student in studenci)
            {
                Console.WriteLine(student.WypiszPelnaNazweIUczelnie());
            }
        }
    }
}
