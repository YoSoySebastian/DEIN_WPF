using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System;

namespace Proyecto_DEIN
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Debes ingresar usuario y contraseña");
                return;
            }

            if (Autenticar(txtUsuario.Text, txtPassword.Password))
            {
                new Principal().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private bool Autenticar(string usuario, string contraseña)
        {
            try
            {
                string connectionString = "server=localhost;port=3306;database=proyecto_dein;uid=root;pwd=root;";

                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE Usuario=@usuario AND Contrasena=@pass";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@pass", contraseña);

                        object result = cmd.ExecuteScalar();
                        int count = 0;
                        if (result != null && int.TryParse(result.ToString(), out count))
                        {
                            return count > 0;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión o consulta:\n" + ex.Message);
                return false;
            }
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            placeholderPassword.Visibility = string.IsNullOrEmpty(txtPassword.Password)
                                             ? Visibility.Visible
                                             : Visibility.Collapsed;
        }
    }
}
