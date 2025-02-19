using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Sklep.Data;
using Sklep.Models;

namespace Sklep.Views
{
    public partial class PanelSprzedazy : Window
    {
        private readonly ObservableCollection<Koszyk> koszyk;
        private decimal saldoPrzedTransakcja;
        private string typKlienta;
        private readonly string AktualnieZalogowanyLogin;
        public PanelSprzedazy(string login)
        {
            InitializeComponent();
            AktualnieZalogowanyLogin = login;
            koszyk = new ObservableCollection<Koszyk>();
            dgKoszyk.ItemsSource = koszyk;
            LoadKlienci();
            LoadProdukty();
        }
        private void LoadKlienci()
        {
            string query = "SELECT IdKlienta, Imie + ' ' + Nazwisko AS Klient, Saldo, TypKlienta FROM Klienci";
            DataTable klienci = DatabaseHelper.ExecuteQuery(query);

            cmbKlienci.ItemsSource = klienci.AsEnumerable()
                .Select(row => new
                {
                    IdKlienta = row.Field<int>("IdKlienta"),
                    Klient = row.Field<string>("Klient"),
                    Saldo = row.Field<decimal>("Saldo"),
                    TypKlienta = row.Field<string>("TypKlienta")
                })
                .ToList();

            cmbKlienci.DisplayMemberPath = "Klient";
            cmbKlienci.SelectedValuePath = "IdKlienta";
        }
        private void LoadProdukty(string filter = null)
        {
            string query = "SELECT IdProduktu, Nazwa, Kategoria, CenaDetaliczna, CenaHurtowa, StanMagazynowy FROM Produkty";
            if (!string.IsNullOrEmpty(filter))
                query += " WHERE Nazwa LIKE @Filter";
            var parameters = new[]
            {
                new SqlParameter("@Filter", SqlDbType.NVarChar) { Value = $"%{filter}%" }
            };
            DataTable produkty = string.IsNullOrEmpty(filter)
                ? DatabaseHelper.ExecuteQuery(query)
                : DatabaseHelper.ExecuteQuery(query, parameters);
            dgProdukty.ItemsSource = produkty.DefaultView;
        }
        private void BtnSzukaj_Click(object sender, RoutedEventArgs e)
        {
            LoadProdukty(txtSearch.Text.Trim());
        }
        private void CmbKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbKlienci.SelectedItem != null)
            {
                dynamic client = cmbKlienci.SelectedItem;
                saldoPrzedTransakcja = client.Saldo;
                typKlienta = client.TypKlienta;
                txtSaldo.Text = $"Saldo: {saldoPrzedTransakcja:C}";
                UpdatePodsumowanie();
            }
        }
        private void DgProdukty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProdukty.SelectedItem is DataRowView selectedProduct)
            {
                decimal cenaProduktu = typKlienta == "Hurtowy"
                    ? Convert.ToDecimal(selectedProduct["CenaHurtowa"]) 
                    : Convert.ToDecimal(selectedProduct["CenaDetaliczna"]);

                txtKwotaNalezna.Text = $"Cena: {cenaProduktu:C}";
            }
        }
        private void BtnDodajDoKoszyka_Click(object sender, RoutedEventArgs e)
        {
            if (dgProdukty.SelectedItem != null)
            {
                DataRowView product = (DataRowView)dgProdukty.SelectedItem;

                int idProduktu = (int)product["IdProduktu"];
                string nazwa = (string)product["Nazwa"];
                decimal cena = typKlienta == "Hurtowy"
                    ? (decimal)product["CenaHurtowa"]
                    : (decimal)product["CenaDetaliczna"];
                int stanMagazynowy = (int)product["StanMagazynowy"];
                var existingItem = koszyk.FirstOrDefault(item => item.IdProduktu == idProduktu);
                if (existingItem != null)
                { 
                    if (existingItem.Ilosc < stanMagazynowy)
                    {
                        existingItem.Ilosc++;
                    }
                    else
                    {
                        MessageBox.Show($"Nie można dodać więcej niż {stanMagazynowy} sztuk produktu {nazwa}.", "Błąd");
                    }
                }
                else
                {
                    if (stanMagazynowy > 0)
                    {
                        koszyk.Add(new Koszyk
                        {
                            IdProduktu = idProduktu,
                            Nazwa = nazwa,
                            Cena = cena,
                            Ilosc = 1
                        });
                    }
                    else
                    {
                        MessageBox.Show($"Produkt {nazwa} jest niedostępny w magazynie.", "Błąd");
                    }
                }
                UpdatePodsumowanie();
            }
        }
        private void BtnUsunZKoszyka_Click(object sender, RoutedEventArgs e)
        {
            if (dgKoszyk.SelectedItem is Koszyk selectedItem)
            {
                koszyk.Remove(selectedItem);
                UpdatePodsumowanie();
            }
        }
        private void UpdatePodsumowanie()
        {
            decimal kwotaNalezna = koszyk.Sum(item => item.Razem);
            txtSaldoPrzed.Text = $"Saldo przed transakcją: {saldoPrzedTransakcja:C}";
            txtKwotaNalezna.Text = $"Kwota należna: {kwotaNalezna:C}";
            txtSaldoPo.Text = $"Saldo po transakcji: {saldoPrzedTransakcja - kwotaNalezna:C}";
        }
        private void BtnFinalizujZakup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbKlienci.SelectedItem == null || koszyk.Count == 0)
                {
                    MessageBox.Show("Proszę wybrać klienta i dodać produkty do koszyka.", "Błąd");
                    return;
                }
                dynamic klient = cmbKlienci.SelectedItem;
                int idKlienta = klient.IdKlienta;
                decimal kwotaNalezna = koszyk.Sum(k => k.Cena * k.Ilosc);
                if (saldoPrzedTransakcja < kwotaNalezna)
                {
                    MessageBox.Show("Klient nie ma wystarczających środków na zakup!", "Błąd");
                    return;
                }
                string insertOrderQuery = @"
                INSERT INTO Zamowienia (IdKlienta, DataZamowienia, KwotaLaczna, Login)
                VALUES (@IdKlienta, GETDATE(), @KwotaLaczna, @Login);
                SELECT SCOPE_IDENTITY();";
                var orderParams = new[]
                {
                    new SqlParameter("@IdKlienta", SqlDbType.Int) { Value = idKlienta },
                    new SqlParameter("@KwotaLaczna", SqlDbType.Decimal) { Value = kwotaNalezna },
                    new SqlParameter("@Login", SqlDbType.NVarChar) { Value = AktualnieZalogowanyLogin }
        };
                int idZamowienia = Convert.ToInt32(DatabaseHelper.ExecuteScalar(insertOrderQuery, orderParams));
                foreach (var koszykItem in koszyk)
                {
                    string insertDetailsQuery = @"
                    INSERT INTO SzczegolyZamowien (IdZamowienia, IdProduktu, Ilosc, Cena)
                    VALUES (@IdZamowienia, @IdProduktu, @Ilosc, @Cena);";
                    var detailParams = new[]
                    {
                        new SqlParameter("@IdZamowienia", SqlDbType.Int) { Value = idZamowienia },
                        new SqlParameter("@IdProduktu", SqlDbType.Int) { Value = koszykItem.IdProduktu },
                        new SqlParameter("@Ilosc", SqlDbType.Int) { Value = koszykItem.Ilosc },
                        new SqlParameter("@Cena", SqlDbType.Decimal) { Value = koszykItem.Cena }
            };

                    DatabaseHelper.ExecuteNonQuery(insertDetailsQuery, detailParams);
                    string updateStockQuery = @"
                    UPDATE Produkty
                    SET StanMagazynowy = StanMagazynowy - @Ilosc
                    WHERE IdProduktu = @IdProduktu";
                    var stockParams = new[]
                    {
                       new SqlParameter("@Ilosc", SqlDbType.Int) { Value = koszykItem.Ilosc },
                       new SqlParameter("@IdProduktu", SqlDbType.Int) { Value = koszykItem.IdProduktu }
            };
                    DatabaseHelper.ExecuteNonQuery(updateStockQuery, stockParams);
                }
                string updateSaldoQuery = @"
                    UPDATE Klienci
                    SET Saldo = Saldo - @KwotaNalezna
                    WHERE IdKlienta = @IdKlienta";
                var saldoParams = new[]
                {
                   new SqlParameter("@KwotaNalezna", SqlDbType.Decimal) { Value = kwotaNalezna },
                   new SqlParameter("@IdKlienta", SqlDbType.Int) { Value = idKlienta }
        };
                DatabaseHelper.ExecuteNonQuery(updateSaldoQuery, saldoParams);
                MessageBox.Show("Zakup został zakończony!", "Sukces");
                koszyk.Clear();
                UpdatePodsumowanie();
                LoadProdukty();
                LoadKlienci();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
