namespace Sklep.Models
{
    public class Produkt
    {
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }
        public decimal CenaDetaliczna { get; set; }
        public decimal CenaHurtowa { get; set; }
        public int StanMagazynowy { get; set; }
    }
}