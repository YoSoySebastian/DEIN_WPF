using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            MessageBox.Show("Producto añadido a la cesta 🛒", "Cesta", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Comprar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Procediendo a la compra 💳", "Compra", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
