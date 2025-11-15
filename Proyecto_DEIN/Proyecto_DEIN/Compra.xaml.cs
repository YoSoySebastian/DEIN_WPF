using Proyecto_DEIN;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Proyecto_Interfaces
{
    public partial class Compra : Window
    {
        public Compra()
        {
            InitializeComponent();
        }

        private void ComprarAhora_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("¡Compra realizada con éxito!", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Logout(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void Home(object sender, EventArgs e)
        {
            new Principal().Show();
            this.Close();
        }

        private void Carrito_Click(object sender, RoutedEventArgs e)
        {
            new Lista().Show();
            this.Close();
        }

        private bool menuAbierto = false;

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            menuAbierto = !menuAbierto;

            if (menuAbierto)
            {
                MenuLateral.Visibility = Visibility.Visible;
                FondoOscuro.Visibility = Visibility.Visible;

                var anim = new DoubleAnimation
                {
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(250),
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                };
                MenuTransform.BeginAnimation(TranslateTransform.XProperty, anim);
            }
            else
            {
                var anim = new DoubleAnimation
                {
                    To = -250,
                    Duration = TimeSpan.FromMilliseconds(250),
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
                };

                anim.Completed += (s, ev) =>
                {
                    MenuLateral.Visibility = Visibility.Collapsed;
                    FondoOscuro.Visibility = Visibility.Collapsed;
                };

                MenuTransform.BeginAnimation(TranslateTransform.XProperty, anim);
            }
        }

        private void CerrarMenu_Click(object sender, MouseButtonEventArgs e)
        {
            Menu_Click(sender, e);
        }
    }
}
