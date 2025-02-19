namespace Sklep.Models
{
    public class Pracownik
    {
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Stanowisko { get; set; }
        public decimal Pensja { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
    }
}