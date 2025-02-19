using System;
using System.Linq;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using Sklep.Data;

namespace Sklep.Views
{
    public partial class RaportSprzedazy : Window
    {
        public RaportSprzedazy()
        {
            InitializeComponent();
            LoadRaporty();
        }
        private void LoadRaporty(string startDate = null, string endDate = null)
        {
            try
            {
                string query = @"SELECT Zamowienia.IdZamowienia,Produkty.Nazwa AS Produkt,SzczegolyZamowien.Ilosc,Klienci.Imie + ' ' + Klienci.Nazwisko AS Klient, 
                Zamowienia.KwotaLaczna,Zamowienia.DataZamowienia,Zamowienia.Login AS Sprzedawca 
                FROM Zamowienia
                INNER JOIN SzczegolyZamowien 
                ON Zamowienia.IdZamowienia = SzczegolyZamowien.IdZamowienia
                INNER JOIN Produkty 
                ON SzczegolyZamowien.IdProduktu = Produkty.IdProduktu
                INNER JOIN Klienci 
                ON Zamowienia.IdKlienta = Klienci.IdKlienta
                WHERE (@StartDate IS NULL OR Zamowienia.DataZamowienia >= @StartDate) AND (@EndDate IS NULL OR Zamowienia.DataZamowienia <= @EndDate)
                ORDER BY Zamowienia.DataZamowienia DESC";
                var parameters = new[]
                {
                    new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = (object)startDate ?? DBNull.Value },
                    new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = (object)endDate ?? DBNull.Value }
                };
                DataTable raporty = DatabaseHelper.ExecuteQuery(query, parameters);
                dgRaporty.ItemsSource = raporty.AsEnumerable().Select(row => new
                {
                    IdZamowienia = row.Field<int>("IdZamowienia"),
                    Produkt = row.Field<string>("Produkt"),
                    Ilosc = row.Field<int>("Ilosc"),
                    Klient = row.Field<string>("Klient"),
                    KwotaLaczna = row.Field<decimal>("KwotaLaczna"),
                    DataZamowienia = row.Field<DateTime>("DataZamowienia").ToString("yyyy-MM-dd HH:mm"),
                    Sprzedawca = row.Field<string>("Sprzedawca")
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania raportu: {ex.Message}", "Błąd");
            }
        }
        private void BtnFiltruj_Click(object sender, RoutedEventArgs e)
        {
            string startDate = dpStartDate.SelectedDate?.ToString("yyyy-MM-dd");
            string endDate = dpEndDate.SelectedDate?.ToString("yyyy-MM-dd");

            LoadRaporty(startDate, endDate);
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}