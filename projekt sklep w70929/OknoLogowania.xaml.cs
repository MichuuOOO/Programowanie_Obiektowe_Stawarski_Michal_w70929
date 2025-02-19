using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Sklep.Views;
using Sklep.Data;
using Sklep.Models;

namespace Sklep
{
    public partial class OknoLogowania : Window
    {
        public OknoLogowania()
        {
            InitializeComponent();
        }
        private void BtnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = txtLogin.Text;
                string haslo = txtHaslo.Password;
                Uzytkownik.AktualnieZalogowanyLogin = login;

                string query = @"
                    SELECT Stanowisko 
                    FROM Pracownicy 
                    WHERE Login = @Login AND Haslo = @Haslo";

                var parameters = new[]
                {
                    new SqlParameter("@Login", SqlDbType.NVarChar) { Value = login },
                    new SqlParameter("@Haslo", SqlDbType.NVarChar) { Value = haslo }
                };

                DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
                if (result.Rows.Count > 0)
                {
                    string stanowisko = result.Rows[0]["Stanowisko"].ToString();

                    switch (stanowisko)
                    {
                        case "Właściciel":
                            MessageBox.Show("Zalogowano jako Właściciel.", "Sukces");
                            PanelWlasciciela panelWlasciciela = new PanelWlasciciela();
                            panelWlasciciela.Show();
                            this.Close();
                            break;

                        case "Pracownik":
                            MessageBox.Show($"Zalogowano jako Pracownik {login}.", "Sukces");
                            PanelPracownika panelPracownika = new PanelPracownika();
                            panelPracownika.Show();
                            this.Close();
                            break;

                        default:
                            MessageBox.Show("Nieznane stanowisko.", "Błąd");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Nieprawidłowy login lub hasło.", "Błąd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd");
            }
        }
        private void BtnZalogujJakoKlient_Click(object sender, RoutedEventArgs e)
        {
            PanelKlienta panelKlienta = new PanelKlienta();
            panelKlienta.Show();
            this.Close();
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}