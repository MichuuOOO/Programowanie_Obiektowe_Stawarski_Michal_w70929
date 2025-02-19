using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using Sklep.Data;
using System.Data.SqlClient;

namespace Sklep.Views
{
    public partial class ZarzadzanieKlientami : Window
    {
        public ZarzadzanieKlientami()
        {
            InitializeComponent();
            LoadKlienci();
        }
        private void LoadKlienci()
        {
            try
            {
                string query = "SELECT IdKlienta, Imie, Nazwisko, Firma, NIP, Email, Telefon, Adres, Saldo, TypKlienta FROM Klienci";
                DataTable klienci = DatabaseHelper.ExecuteQuery(query);

                if (klienci != null)
                {
                    dgKlienci.ItemsSource = klienci.DefaultView;
                }
                else
                {
                    MessageBox.Show("Brak dostępnych klientów.", "Informacja");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania klientów: {ex.Message}", "Błąd");
            }
        }
        private void BtnDodajKlienta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txtImie.Text.Trim();
                string nazwisko = txtNazwisko.Text.Trim();
                string firma = string.IsNullOrWhiteSpace(txtFirma.Text) || txtFirma.Text == "Firma (opcjonalne)" ? null : txtFirma.Text.Trim();
                string nip = string.IsNullOrWhiteSpace(txtNIP.Text) || txtNIP.Text == "NIP (opcjonalne)" ? null : txtNIP.Text.Trim();
                string email = string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text == "Email" ? null : txtEmail.Text.Trim();
                string telefon = string.IsNullOrWhiteSpace(txtTelefon.Text) || txtTelefon.Text == "Telefon" ? null : txtTelefon.Text.Trim();
                string adres = string.IsNullOrWhiteSpace(txtAdres.Text) || txtAdres.Text == "Adres" ? null : txtAdres.Text.Trim();
                decimal saldo = decimal.TryParse(txtSaldo.Text, out decimal parsedSaldo) ? parsedSaldo : 0;
                string typKlienta = (cmbTypKlienta.SelectedItem as ComboBoxItem)?.Content.ToString();
                if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || typKlienta == null)
                {
                    MessageBox.Show("Proszę wprowadzić wymagane dane (Imię, Nazwisko, Typ Klienta).", "Błąd");
                    return;
                }
                string query = @"INSERT INTO Klienci (Imie, Nazwisko, Firma, NIP, Email, Telefon, Adres, Saldo, TypKlienta)
                    VALUES (@Imie, @Nazwisko, @Firma, @NIP, @Email, @Telefon, @Adres, @Saldo, @TypKlienta)";
                var parameters = new[]
                {
                    new SqlParameter("@Imie", SqlDbType.NVarChar) { Value = imie },
                    new SqlParameter("@Nazwisko", SqlDbType.NVarChar) { Value = nazwisko },
                    new SqlParameter("@Firma", SqlDbType.NVarChar) { Value = (object)firma ?? DBNull.Value },
                    new SqlParameter("@NIP", SqlDbType.NVarChar) { Value = (object)nip ?? DBNull.Value },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = (object)email ?? DBNull.Value },
                    new SqlParameter("@Telefon", SqlDbType.NVarChar) { Value = (object)telefon ?? DBNull.Value },
                    new SqlParameter("@Adres", SqlDbType.NVarChar) { Value = (object)adres ?? DBNull.Value },
                    new SqlParameter("@Saldo", SqlDbType.Decimal) { Value = saldo },
                    new SqlParameter("@TypKlienta", SqlDbType.NVarChar) { Value = typKlienta }
        };
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Klient został dodany pomyślnie.", "Sukces");
                    LoadKlienci();
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać klienta.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnUsunKlienta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgKlienci.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać klienta do usunięcia.", "Informacja");
                    return;
                }
                DataRowView row = (DataRowView)dgKlienci.SelectedItem;
                int idKlienta = (int)row["IdKlienta"];
                string query = "DELETE FROM Klienci WHERE IdKlienta = @IdKlienta";
                var parameters = new[]
                {
                    new SqlParameter("@IdKlienta", SqlDbType.Int) { Value = idKlienta }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Klient został usunięty.", "Sukces");
                    LoadKlienci();
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć klienta.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnEdytujKlienta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgKlienci.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać klienta do edycji.", "Informacja");
                    return;
                }
                DataRowView selectedRow = (DataRowView)dgKlienci.SelectedItem;
                int idKlienta = (int)selectedRow["IdKlienta"];
                string imie = txtImie.Text.Trim();
                string nazwisko = txtNazwisko.Text.Trim();
                string firma = string.IsNullOrWhiteSpace(txtFirma.Text) ? null : txtFirma.Text.Trim();
                string nip = string.IsNullOrWhiteSpace(txtNIP.Text) ? null : txtNIP.Text.Trim();
                string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                string telefon = string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim();
                string adres = string.IsNullOrWhiteSpace(txtAdres.Text) ? null : txtAdres.Text.Trim();
                decimal saldo = decimal.TryParse(txtSaldo.Text, out decimal parsedSaldo) ? parsedSaldo : 0;
                string typKlienta = (cmbTypKlienta.SelectedItem as ComboBoxItem)?.Content.ToString();
                if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || typKlienta == null)
                {
                    MessageBox.Show("Proszę wprowadzić wymagane dane (Imię, Nazwisko, Typ Klienta).", "Błąd");
                    return;
                }
                string query = @"
                    UPDATE Klienci
                    SET Imie = @Imie,Nazwisko = @Nazwisko,Firma = @Firma,NIP = @NIP,Email = @Email,Telefon = @Telefon,Adres = @Adres,Saldo = @Saldo,TypKlienta = @TypKlienta
                    WHERE IdKlienta = @IdKlienta";
                var parameters = new[]
                {
                    new SqlParameter("@IdKlienta", SqlDbType.Int) { Value = idKlienta },
                    new SqlParameter("@Imie", SqlDbType.NVarChar) { Value = imie },
                    new SqlParameter("@Nazwisko", SqlDbType.NVarChar) { Value = nazwisko },
                    new SqlParameter("@Firma", SqlDbType.NVarChar) { Value = (object)firma ?? DBNull.Value },
                    new SqlParameter("@NIP", SqlDbType.NVarChar) { Value = (object)nip ?? DBNull.Value },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = (object)email ?? DBNull.Value },
                    new SqlParameter("@Telefon", SqlDbType.NVarChar) { Value = (object)telefon ?? DBNull.Value },
                    new SqlParameter("@Adres", SqlDbType.NVarChar) { Value = (object)adres ?? DBNull.Value },
                    new SqlParameter("@Saldo", SqlDbType.Decimal) { Value = saldo },
                    new SqlParameter("@TypKlienta", SqlDbType.NVarChar) { Value = typKlienta }
                };
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dane klienta zostały zaktualizowane.", "Sukces");
                    LoadKlienci();
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych klienta.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd");
            }
        }
        private void DgKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgKlienci.SelectedItem == null)
                return;
            DataRowView selectedRow = (DataRowView)dgKlienci.SelectedItem;
            txtImie.Text = selectedRow["Imie"].ToString();
            txtNazwisko.Text = selectedRow["Nazwisko"].ToString();
            txtFirma.Text = selectedRow["Firma"] == DBNull.Value ? "" : selectedRow["Firma"].ToString();
            txtNIP.Text = selectedRow["NIP"] == DBNull.Value ? "" : selectedRow["NIP"].ToString();
            txtEmail.Text = selectedRow["Email"] == DBNull.Value ? "" : selectedRow["Email"].ToString();
            txtTelefon.Text = selectedRow["Telefon"] == DBNull.Value ? "" : selectedRow["Telefon"].ToString();
            txtAdres.Text = selectedRow["Adres"] == DBNull.Value ? "" : selectedRow["Adres"].ToString();
            txtSaldo.Text = selectedRow["Saldo"].ToString();
            cmbTypKlienta.SelectedItem = cmbTypKlienta.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == selectedRow["TypKlienta"].ToString());

            txtImie.Foreground = Brushes.Black;
            txtNazwisko.Foreground = Brushes.Black;
            txtFirma.Foreground = Brushes.Black;
            txtNIP.Foreground = Brushes.Black;
            txtEmail.Foreground = Brushes.Black;
            txtTelefon.Foreground = Brushes.Black;
            txtAdres.Foreground = Brushes.Black;
            txtSaldo.Foreground = Brushes.Black;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var placeholderTexts = new[] { "Imię", "Nazwisko", "Firma (opcjonalne)", "NIP (opcjonalne)", "Email", "Telefon", "Adres", "Saldo" };

                if (placeholderTexts.Contains(textBox.Text))
                {
                    textBox.Text = string.Empty;
                    textBox.Foreground = Brushes.Black;
                }
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "txtImie") textBox.Text = "Imię";
                else if (textBox.Name == "txtNazwisko") textBox.Text = "Nazwisko";
                else if (textBox.Name == "txtFirma") textBox.Text = "Firma (opcjonalne)";
                else if (textBox.Name == "txtNIP") textBox.Text = "NIP (opcjonalne)";
                else if (textBox.Name == "txtEmail") textBox.Text = "Email";
                else if (textBox.Name == "txtTelefon") textBox.Text = "Telefon";
                else if (textBox.Name == "txtAdres") textBox.Text = "Adres";
                else if (textBox.Name == "txtSaldo") textBox.Text = "Saldo";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}