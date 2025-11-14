using System.Windows;

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
    }
}
