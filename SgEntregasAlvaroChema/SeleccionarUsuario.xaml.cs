using SgEntregasAlvaroChema.viewModel;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para SeleccionarUsuario.xaml
    /// </summary>
    public partial class SeleccionarUsuario : Window
    {
        CollectionViewModel coleccionVM;
        List<clientes> clientesList = new List<clientes>();
        VentanaOrdenador ventanaAnterior;
        public SeleccionarUsuario(VentanaOrdenador ventanaAnterior)
        {
            InitializeComponent();
            coleccionVM = (CollectionViewModel)this.Resources["ColeccionVM"];
            this.ventanaAnterior = ventanaAnterior;
            cargarClientes();
        }

        private void cargarClientes()
        {
            cmb_clientes.Items.Clear();
            foreach (var cli in coleccionVM.ListaClientes)
            {
                cmb_clientes.Items.Add(cli.nombre);
                clientesList.Add(cli);
            }
            cmb_clientes.SelectedIndex = 0;
            
        }

        private void btnCargarPedidos_Click(object sender, RoutedEventArgs e)
        {
            clientes cliente = clientesList[cmb_clientes.SelectedIndex];
            GestionPedidos ventana = new GestionPedidos(cliente,this);
            this.Visibility = Visibility.Hidden;
            ventana.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }
    }
}
