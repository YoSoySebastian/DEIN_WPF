using Proyecto_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_DEIN
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void ProductoDestacado_Click(object sender, RoutedEventArgs e)
        {
            new Producto().Show();
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
    }
}
