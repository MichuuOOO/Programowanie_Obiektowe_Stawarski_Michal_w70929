using System.ComponentModel;

namespace Sklep.Models
{
    public class Koszyk : INotifyPropertyChanged
    {
        private int ilosc;
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc
        {
            get => ilosc;
            set
            {
                if (ilosc != value)
                {
                    ilosc = value;
                    OnPropertyChanged(nameof(Ilosc));
                    OnPropertyChanged(nameof(Razem)); 
                }
            }
        }
        public decimal Razem => Cena * Ilosc;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}