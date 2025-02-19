using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using Sklep.Data;
using System.Data.SqlClient;

namespace Sklep.Views
{
    public partial class ZarzadzanieProduktami : Window
    {
        public ZarzadzanieProduktami()
        {
            InitializeComponent();
            LoadProdukty();
        }
        private void LoadProdukty()
        {
            try
            {
                string query = "SELECT IdProduktu, Nazwa, Kategoria, CenaDetaliczna, CenaHurtowa, StanMagazynowy FROM Produkty";
                DataTable produkty = DatabaseHelper.ExecuteQuery(query);

                if (produkty != null)
                {
                    dgProdukty.ItemsSource = produkty.DefaultView;
                }
                else
                {
                    MessageBox.Show("Brak dostępnych produktów.", "Informacja");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania produktów: {ex.Message}", "Błąd");
            }
        }
        private void BtnDodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nazwa = txtNazwa.Text.Trim();
                string kategoria = txtKategoria.Text.Trim();
                decimal cenaDetaliczna = decimal.Parse(txtCenaDetaliczna.Text.Trim());
                decimal cenaHurtowa = decimal.Parse(txtCenaHurtowa.Text.Trim());
                int stanMagazynowy = int.Parse(txtStanMagazynowy.Text.Trim());

                if (string.IsNullOrWhiteSpace(nazwa) || cenaDetaliczna <= 0 || cenaHurtowa <= 0 || stanMagazynowy < 0)
                {
                    MessageBox.Show("Proszę wprowadzić poprawne dane.", "Błąd");
                    return;
                }

                string query = @"
                    INSERT INTO Produkty (Nazwa, Kategoria, CenaDetaliczna, CenaHurtowa, StanMagazynowy)
                    VALUES (@Nazwa, @Kategoria, @CenaDetaliczna, @CenaHurtowa, @StanMagazynowy)";

                var parameters = new[]
                {
                    new SqlParameter("@Nazwa", SqlDbType.NVarChar) { Value = nazwa },
                    new SqlParameter("@Kategoria", SqlDbType.NVarChar) { Value = kategoria },
                    new SqlParameter("@CenaDetaliczna", SqlDbType.Decimal) { Value = cenaDetaliczna },
                    new SqlParameter("@CenaHurtowa", SqlDbType.Decimal) { Value = cenaHurtowa },
                    new SqlParameter("@StanMagazynowy", SqlDbType.Int) { Value = stanMagazynowy }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Produkt został dodany pomyślnie.", "Sukces");
                    LoadProdukty();
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać produktu.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnUsunProdukt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProdukty.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać produkt do usunięcia.", "Informacja");
                    return;
                }

                DataRowView row = (DataRowView)dgProdukty.SelectedItem;
                int idProduktu = (int)row["IdProduktu"];

                string query = "DELETE FROM Produkty WHERE IdProduktu = @IdProduktu";
                var parameters = new[]
                {
                    new SqlParameter("@IdProduktu", SqlDbType.Int) { Value = idProduktu }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Produkt został usunięty.", "Sukces");
                    LoadProdukty();
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć produktu.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnEdytujProdukt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProdukty.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać produkt do edycji.", "Informacja");
                    return;
                }
                DataRowView selectedRow = (DataRowView)dgProdukty.SelectedItem;
                int idProduktu = (int)selectedRow["IdProduktu"];
                string nazwa = txtNazwa.Text.Trim();
                string kategoria = txtKategoria.Text.Trim();
                decimal cenaDetaliczna = decimal.Parse(txtCenaDetaliczna.Text.Trim());
                decimal cenaHurtowa = decimal.Parse(txtCenaHurtowa.Text.Trim());
                int stanMagazynowy = int.Parse(txtStanMagazynowy.Text.Trim());

                if (string.IsNullOrWhiteSpace(nazwa) || cenaDetaliczna <= 0 || cenaHurtowa <= 0 || stanMagazynowy < 0)
                {
                    MessageBox.Show("Proszę wprowadzić poprawne dane.", "Błąd");
                    return;
                }
                string query = @"
                    UPDATE Produkty
                    SET Nazwa = @Nazwa,
                        Kategoria = @Kategoria,
                        CenaDetaliczna = @CenaDetaliczna,
                        CenaHurtowa = @CenaHurtowa,
                        StanMagazynowy = @StanMagazynowy
                    WHERE IdProduktu = @IdProduktu";
                var parameters = new[]
                {
                    new SqlParameter("@IdProduktu", SqlDbType.Int) { Value = idProduktu },
                    new SqlParameter("@Nazwa", SqlDbType.NVarChar) { Value = nazwa },
                    new SqlParameter("@Kategoria", SqlDbType.NVarChar) { Value = kategoria },
                    new SqlParameter("@CenaDetaliczna", SqlDbType.Decimal) { Value = cenaDetaliczna },
                    new SqlParameter("@CenaHurtowa", SqlDbType.Decimal) { Value = cenaHurtowa },
                    new SqlParameter("@StanMagazynowy", SqlDbType.Int) { Value = stanMagazynowy }
                };
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Produkt został zaktualizowany.", "Sukces");
                    LoadProdukty();
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować produktu.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void DgProdukty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProdukty.SelectedItem == null)
                return;
            DataRowView selectedRow = (DataRowView)dgProdukty.SelectedItem;
            txtNazwa.Text = selectedRow["Nazwa"].ToString();
            txtKategoria.Text = selectedRow["Kategoria"].ToString();
            txtCenaDetaliczna.Text = selectedRow["CenaDetaliczna"].ToString();
            txtCenaHurtowa.Text = selectedRow["CenaHurtowa"].ToString();
            txtStanMagazynowy.Text = selectedRow["StanMagazynowy"].ToString();

            txtNazwa.Foreground = Brushes.Black;
            txtKategoria.Foreground = Brushes.Black;
            txtCenaDetaliczna.Foreground = Brushes.Black;
            txtCenaHurtowa.Foreground = Brushes.Black;
            txtStanMagazynowy.Foreground = Brushes.Black;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox.Text == "Nazwa produktu" || textBox.Text == "Kategoria" ||
                textBox.Text == "Cena detaliczna" || textBox.Text == "Cena hurtowa" ||
                textBox.Text == "Stan magazynowy")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "txtNazwa") textBox.Text = "Nazwa produktu";
                else if (textBox.Name == "txtKategoria") textBox.Text = "Kategoria";
                else if (textBox.Name == "txtCenaDetaliczna") textBox.Text = "Cena detaliczna";
                else if (textBox.Name == "txtCenaHurtowa") textBox.Text = "Cena hurtowa";
                else if (textBox.Name == "txtStanMagazynowy") textBox.Text = "Stan magazynowy";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}