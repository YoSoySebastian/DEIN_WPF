using Proyecto_DEIN;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Proyecto_Interfaces
{
    public partial class Producto : Window
    {
        public Producto()
        {
            InitializeComponent();
        }

        private void Capacidad_Click(object sender, RoutedEventArgs e)
        {
            foreach (var child in CapacidadPanel.Children)
            {
                if (child is Border border && border.Child is Button btn)
                {
                    border.Background = Brushes.White;
                    border.BorderBrush = Brushes.Gray;
                    border.BorderThickness = new Thickness(1);
                    btn.FontWeight = FontWeights.SemiBold;
                }
            }

            if (sender is Button selectedButton && selectedButton.Parent is Border selectedBorder)
            {
                selectedBorder.Background = new SolidColorBrush(Color.FromRgb(173, 216, 230)); // Azul claro
                selectedBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 122, 204));  // Azul fuerte
                selectedBorder.BorderThickness = new Thickness(2);
                selectedButton.FontWeight = FontWeights.Bold;
            }
        }

        private void AñadirCesta_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Producto añadido a la cesta", "Cesta", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComprarYa_Click(object sender, RoutedEventArgs e)
        {
            new Compra().Show();
            this.Close();
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