namespace Sklep.Models
{
    public class Klient
    {
        public int IdKlienta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Firma { get; set; }
        public string NIP { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public decimal Saldo { get; set; }
        public string TypKlienta { get; set; } 
    }
}