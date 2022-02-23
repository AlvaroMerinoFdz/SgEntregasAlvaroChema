using SgEntregasAlvaroChema.viewModel;
using System.Windows;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para VentanaOrdenador.xaml
    /// </summary>
    public partial class VentanaOrdenador : Window
    {
        private MainWindow ventanaAnterior;
        private CollectionViewModel coleccionVM;
        public VentanaOrdenador(MainWindow ventana)
        {
            InitializeComponent();
            coleccionVM = (CollectionViewModel)this.Resources["ColeccionVM"];
            this.ventanaAnterior = ventana;
        }

        private void btn_gestion_clientes_Click(object sender, RoutedEventArgs e)
        {
            GestionClientes ventana = new GestionClientes(this);
            this.Visibility = Visibility.Hidden;
            ventana.Show();
        }

        private void btn_gestion_pedidos_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarUsuario ventana = new SeleccionarUsuario(this);
            this.Visibility = Visibility.Hidden;
            ventana.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanaAnterior.Visibility = Visibility.Visible;

        }
    }
}
