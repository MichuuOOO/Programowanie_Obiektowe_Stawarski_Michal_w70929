namespace Zad2_3.Klasy
{
    public class Uczen : Osoba
    {
        public required string Szkola { get; set; }
        public bool MozeSamWracacDoDomu { get; set; }

        public override string ZwrocPelnaNazwe()
        {
            return $"{base.ZwrocPelnaNazwe()} (Uczeń)";
        }

        public bool CanGoAloneToHome()
        {
            return GetAge() >= 12 || MozeSamWracacDoDomu;
        }
    }
}
