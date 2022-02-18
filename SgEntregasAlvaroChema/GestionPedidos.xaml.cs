using SgEntregasAlvaroChema.viewModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para GestionPedidos.xaml
    /// </summary>
    public partial class GestionPedidos : Window
    {
        private CollectionViewModel coleccionVM;
        private clientes cliente;
        public GestionPedidos(clientes cliente)
        {
            InitializeComponent();
            coleccionVM = (CollectionViewModel)this.Resources["ColeccionVM"];
            this.cliente = cliente;
            coleccionVM.cargarPedidosCliente(cliente.dni);
        }
        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Seleccionado_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dgPedidos.SelectedItems.Count > 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void Add_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddPedido ventana = new AddPedido(coleccionVM, cliente);
            ventana.ShowDialog();
        }
        private void Modificar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            pedidos pedido = (pedidos)dgPedidos.SelectedItem;
            ModificarPedido modificar = new ModificarPedido(pedido, coleccionVM);
            modificar.ShowDialog();
        }

        private void Eliminar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult resp = (DialogResult)System.Windows.MessageBox.Show("¿Deseas borrar el elemento seleccionado?", "Borrar Cliente", MessageBoxButton.YesNo, (MessageBoxImage)MessageBoxIcon.Information);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                //Ahora lo eliminamos de la BBDD
                coleccionVM.objBD.pedidos.Remove((pedidos)dgPedidos.SelectedItem);
                //Lo eliminamos de la lista del collection view model
                coleccionVM.ListaPedidos.Remove((pedidos)dgPedidos.SelectedItem);
                System.Windows.Forms.MessageBox.Show("Pedido eliminado correctamente...", "Pedido Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GuardarBBDD_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            coleccionVM.guardarDatos();
        }
    }
}
