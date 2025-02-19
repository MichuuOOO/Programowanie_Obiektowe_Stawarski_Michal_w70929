using Sklep.Models;
using System.Windows;

namespace Sklep.Views
{
    public partial class PanelPracownika : Window
    {
        public PanelPracownika()
        {
            InitializeComponent();
        }
        private void BtnZarzadzanieProduktami_Click(object sender, RoutedEventArgs e)
        {
            ZarzadzanieProduktami zarzadzanieProduktami = new ZarzadzanieProduktami();
            zarzadzanieProduktami.Show();
        }
        private void BtnZarzadzanieKlientami_Click(object sender, RoutedEventArgs e)
        {
            ZarzadzanieKlientami zarzadzanieKlientami = new ZarzadzanieKlientami();
            zarzadzanieKlientami.Show();
        }
        private void BtnPanelSprzedazy_Click(object sender, RoutedEventArgs e)
        {
            PanelSprzedazy panelSprzedazy = new PanelSprzedazy(Uzytkownik.AktualnieZalogowanyLogin);
            panelSprzedazy.Show();
        }
        private void BtnRaportSprzedazy_Click(object sender, RoutedEventArgs e)
        {
            RaportSprzedazy raportSprzedazy = new RaportSprzedazy();
            raportSprzedazy.Show();
        }
        private void BtnWyloguj_Click(object sender, RoutedEventArgs e)
        {
            OknoLogowania oknologowania = new OknoLogowania();
            oknologowania.Show();
            this.Close();
        }
    }
} 