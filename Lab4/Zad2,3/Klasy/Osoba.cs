using Zad2_3.Interfejsy;

namespace Zad2_3.Klasy
{
    public class Osoba : IOsoba
    {
        public required string Imie { get; set; }
        public required string Nazwisko { get; set; }
        public required string Pesel { get; set; }

        public virtual string ZwrocPelnaNazwe() => $"{Imie} {Nazwisko}";

        public int GetAge()
        {
            int year = int.Parse(Pesel[..2]);
            int month = int.Parse(Pesel.Substring(2, 2));
            year += (month > 20) ? 2000 : 1900;
            return DateTime.Now.Year - year;
        }

        public string GetGender()
        {
            int genderDigit = int.Parse(Pesel[9].ToString());
            return (genderDigit % 2 == 0) ? "Kobieta" : "Mężczyzna";
        }
    }
}
