namespace Zad2
{
    public class SamochodOsobowy(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg, float waga, float pojemnoscSilnika, int iloscOsob) : Samochod(marka, model, nadwozie, kolor, rokProdukcji, przebieg)
    {
        private readonly float Waga = Math.Clamp(waga, 2.0f, 4.5f);
        private readonly float PojemnoscSilnika = Math.Clamp(pojemnoscSilnika, 0.8f, 3.0f);
        private readonly int IloscOsob = iloscOsob;

        public override void View()
        {
            base.View();
            Console.WriteLine($"Waga: {Waga} t, Pojemnosc Silnika: {PojemnoscSilnika} L, Ilosc Osob: {IloscOsob}");
        }
    }
}
