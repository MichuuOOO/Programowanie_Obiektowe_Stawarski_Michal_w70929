namespace Zad2
{
    public class Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg)
    {
        protected string Marka = marka;
        protected string Model = model;
        protected string Nadwozie = nadwozie;
        protected string Kolor = kolor;
        protected int RokProdukcji = rokProdukcji;
        protected int Przebieg = Math.Max(przebieg, 0);

        public virtual void View()
        {
            Console.WriteLine($"Samochod: {Marka} {Model}, Nadwozie: {Nadwozie}, Kolor: {Kolor}, Rok: {RokProdukcji}, Przebieg: {Przebieg} km");
        }
    }
}
