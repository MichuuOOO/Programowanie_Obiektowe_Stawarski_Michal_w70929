using System;
using System.Windows;
using System.Data;
using Sklep.Data;

namespace Sklep.Views
{
    public partial class PanelKlienta : Window
    {
        public PanelKlienta()
        {
            InitializeComponent();
            LoadProdukty();
        }
        private void LoadProdukty()
        {
            try
            {
                string query = "SELECT Nazwa AS Produkt, CenaDetaliczna AS Cena, StanMagazynowy AS Ilość FROM Produkty";
                DataTable produkty = DatabaseHelper.ExecuteQuery(query);

                dgProdukty.ItemsSource = produkty.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania produktów: {ex.Message}", "Błąd");
            }
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            OknoLogowania oknologowania = new OknoLogowania();
            oknologowania.Show();
            this.Close();
        }
    }
}


