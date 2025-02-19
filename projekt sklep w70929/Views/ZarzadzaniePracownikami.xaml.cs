using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using Sklep.Data;
using System.Data.SqlClient;

namespace Sklep.Views
{
    public partial class ZarzadzaniePracownikami : Window
    {
        public ZarzadzaniePracownikami()
        {
            InitializeComponent();
            LoadPracownicy();
        }

        private void LoadPracownicy()
        {
            try
            {
                string query = "SELECT IdPracownika, Imie, Nazwisko, Email, Telefon, Adres, Stanowisko, Pensja, Login FROM Pracownicy";
                DataTable pracownicy = DatabaseHelper.ExecuteQuery(query);

                if (pracownicy != null)
                {
                    dgPracownicy.ItemsSource = pracownicy.DefaultView;
                }
                else
                {
                    MessageBox.Show("Brak dostępnych pracowników.", "Informacja");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ładowania pracowników: {ex.Message}", "Błąd");
            }
        }
        private void BtnDodajPracownika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txtImie.Text.Trim();
                string nazwisko = txtNazwisko.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telefon = txtTelefon.Text.Trim();
                string adres = txtAdres.Text.Trim();
                string stanowisko = txtStanowisko.Text.Trim();
                decimal pensja = decimal.Parse(txtPensja.Text.Trim());
                string login = txtLogin.Text.Trim();
                string haslo = txtHaslo.Password.Trim();

                if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(haslo))
                {
                    MessageBox.Show("Proszę wprowadzić wszystkie wymagane dane.", "Błąd");
                    return;
                }

                string query = @"
                    INSERT INTO Pracownicy (Imie, Nazwisko, Email, Telefon, Adres, Stanowisko, Pensja, Login, Haslo)
                    VALUES (@Imie, @Nazwisko, @Email, @Telefon, @Adres, @Stanowisko, @Pensja, @Login, @Haslo)";

                var parameters = new[]
                {
                    new SqlParameter("@Imie", SqlDbType.NVarChar) { Value = imie },
                    new SqlParameter("@Nazwisko", SqlDbType.NVarChar) { Value = nazwisko },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
                    new SqlParameter("@Telefon", SqlDbType.NVarChar) { Value = telefon },
                    new SqlParameter("@Adres", SqlDbType.NVarChar) { Value = adres },
                    new SqlParameter("@Stanowisko", SqlDbType.NVarChar) { Value = stanowisko },
                    new SqlParameter("@Pensja", SqlDbType.Decimal) { Value = pensja },
                    new SqlParameter("@Login", SqlDbType.NVarChar) { Value = login },
                    new SqlParameter("@Haslo", SqlDbType.NVarChar) { Value = haslo }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Pracownik został dodany pomyślnie.", "Sukces");
                    LoadPracownicy();
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać pracownika.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnUsunPracownika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgPracownicy.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać pracownika do usunięcia.", "Informacja");
                    return;
                }

                DataRowView row = (DataRowView)dgPracownicy.SelectedItem;
                int idPracownika = (int)row["IdPracownika"];

                string query = "DELETE FROM Pracownicy WHERE IdPracownika = @IdPracownika";
                var parameters = new[]
                {
                    new SqlParameter("@IdPracownika", SqlDbType.Int) { Value = idPracownika }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Pracownik został usunięty.", "Sukces");
                    LoadPracownicy();
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć pracownika.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnEdytujPracownika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgPracownicy.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać pracownika do edycji.", "Informacja");
                    return;
                }

                DataRowView selectedRow = (DataRowView)dgPracownicy.SelectedItem;
                int idPracownika = (int)selectedRow["IdPracownika"];

                string imie = txtImie.Text.Trim();
                string nazwisko = txtNazwisko.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telefon = txtTelefon.Text.Trim();
                string adres = txtAdres.Text.Trim();
                string stanowisko = txtStanowisko.Text.Trim();
                decimal pensja = decimal.Parse(txtPensja.Text.Trim());
                string login = txtLogin.Text.Trim();
                string haslo = txtHaslo.Password.Trim();

                if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) ||
                    string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(haslo))
                {
                    MessageBox.Show("Proszę wprowadzić wszystkie wymagane dane.", "Błąd");
                    return;
                }

                string query = @"
                    UPDATE Pracownicy
                    SET Imie = @Imie,
                        Nazwisko = @Nazwisko,
                        Email = @Email,
                        Telefon = @Telefon,
                        Adres = @Adres,
                        Stanowisko = @Stanowisko,
                        Pensja = @Pensja,
                        Login = @Login,
                        Haslo = @Haslo
                    WHERE IdPracownika = @IdPracownika";

                var parameters = new[]
                {
                    new SqlParameter("@IdPracownika", SqlDbType.Int) { Value = idPracownika },
                    new SqlParameter("@Imie", SqlDbType.NVarChar) { Value = imie },
                    new SqlParameter("@Nazwisko", SqlDbType.NVarChar) { Value = nazwisko },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
                    new SqlParameter("@Telefon", SqlDbType.NVarChar) { Value = telefon },
                    new SqlParameter("@Adres", SqlDbType.NVarChar) { Value = adres },
                    new SqlParameter("@Stanowisko", SqlDbType.NVarChar) { Value = stanowisko },
                    new SqlParameter("@Pensja", SqlDbType.Decimal) { Value = pensja },
                    new SqlParameter("@Login", SqlDbType.NVarChar) { Value = login },
                    new SqlParameter("@Haslo", SqlDbType.NVarChar) { Value = haslo }
                };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Pracownik został zaktualizowany.", "Sukces");
                    LoadPracownicy();
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych pracownika.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void DgPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPracownicy.SelectedItem == null)
                return;

            DataRowView selectedRow = (DataRowView)dgPracownicy.SelectedItem;

            txtImie.Text = selectedRow["Imie"].ToString();
            txtNazwisko.Text = selectedRow["Nazwisko"].ToString();
            txtEmail.Text = selectedRow["Email"].ToString();
            txtTelefon.Text = selectedRow["Telefon"].ToString();
            txtAdres.Text = selectedRow["Adres"].ToString();
            txtStanowisko.Text = selectedRow["Stanowisko"].ToString();
            txtPensja.Text = selectedRow["Pensja"].ToString();
            txtLogin.Text = selectedRow["Login"].ToString();

            txtImie.Foreground = Brushes.Black;
            txtNazwisko.Foreground = Brushes.Black;
            txtEmail.Foreground = Brushes.Black;
            txtTelefon.Foreground = Brushes.Black;
            txtAdres.Foreground = Brushes.Black;
            txtStanowisko.Foreground = Brushes.Black;
            txtPensja.Foreground = Brushes.Black;
            txtLogin.Foreground = Brushes.Black;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox.Text == "Imię" || textBox.Text == "Nazwisko" || textBox.Text == "Email" ||
                textBox.Text == "Telefon" || textBox.Text == "Adres" || textBox.Text == "Stanowisko" ||
                textBox.Text == "Pensja" || textBox.Text == "Login")
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
                if (textBox.Name == "txtImie") textBox.Text = "Imię";
                else if (textBox.Name == "txtNazwisko") textBox.Text = "Nazwisko";
                else if (textBox.Name == "txtEmail") textBox.Text = "Email";
                else if (textBox.Name == "txtTelefon") textBox.Text = "Telefon";
                else if (textBox.Name == "txtAdres") textBox.Text = "Adres";
                else if (textBox.Name == "txtStanowisko") textBox.Text = "Stanowisko";
                else if (textBox.Name == "txtPensja") textBox.Text = "Pensja";
                else if (textBox.Name == "txtLogin") textBox.Text = "Login";

                textBox.Foreground = Brushes.Gray;
            }
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}