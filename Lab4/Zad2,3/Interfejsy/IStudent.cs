namespace Zad2_3.Interfejsy
{
        public interface IStudent : IOsoba
        {
            string Uczelnia { get; set; }
            string Kierunek { get; set; }
            int Rok { get; set; }
            int Semestr { get; set; }
        }
}


