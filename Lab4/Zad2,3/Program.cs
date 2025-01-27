using Zad2_3.Klasy;
using Zad2_3.Interfejsy;
using Zad2_3.Rozszerzenia;

namespace Zad2_3
{
    class Program
    {
        static void Main()
        {
            var uczen1 = new Uczen { Imie = "Jan", Nazwisko = "Kowalski", Pesel = "07123112345", Szkola = "ZSP5", MozeSamWracacDoDomu = false };
            var uczen2 = new Uczen { Imie = "Anna", Nazwisko = "Nowak", Pesel = "10123122345", Szkola = "ZSP5", MozeSamWracacDoDomu = true };
            var nauczyciel = new Nauczyciel { Imie = "Maria", Nazwisko = "Wiśniewska", Pesel = "81010112345", TytulNaukowy = "Mgr" };
            nauczyciel.PodwladniUczniowie.Add(uczen1);
            nauczyciel.PodwladniUczniowie.Add(uczen2);
            var student1 = new StudentWSIiZ { Imie = "Michał", Nazwisko = "Stawarski", Pesel = "99123112345", Uczelnia = "WSIiZ", Kierunek = "Informatyka", Rok = 2, Semestr = 3 };
            var student2 = new StudentWSIiZ { Imie = "Marta", Nazwisko = "Zielińska", Pesel = "98120122345", Uczelnia = "WSIiZ", Kierunek = "Zarządzanie", Rok = 1, Semestr = 2 };
            var studenciWSIiZ = new List<StudentWSIiZ> { student1, student2 };

            var osoby = new List<IOsoba> { uczen1, uczen2, nauczyciel, student1, student2 };

            Console.WriteLine("Wszystkie osoby:");
            osoby.WypiszOsoby();

            osoby.PosortujOsobyPoNazwisku();
            Console.WriteLine("\nOsoby posortowane po nazwisku:");
            osoby.WypiszOsoby();

            Console.WriteLine("\nStudenci WSIiZ:");
            studenciWSIiZ.WypiszPelneNazwyIUczelnie();

            Console.WriteLine();
            nauczyciel.WypiszUczniowMogacychWrocicSamodzielnie();
        }
    }
}
