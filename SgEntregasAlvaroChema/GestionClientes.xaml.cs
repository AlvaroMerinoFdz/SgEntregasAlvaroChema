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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para GestionClientes.xaml
    /// </summary>
    public partial class GestionClientes : Window
    {
        private CollectionViewModel coleccionVM;
        private VentanaOrdenador ventanaAnterior;
        public GestionClientes(VentanaOrdenador ventanaAnterior)
        {
            InitializeComponent();
            coleccionVM = (CollectionViewModel)this.Resources["ColeccionVM"];
            this.ventanaAnterior = ventanaAnterior;
        }
        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Seleccionado_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0)
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
            AddCliente ventana = new AddCliente(coleccionVM);
            ventana.ShowDialog();
        }
        private void Modificar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int pos = lstClientes.SelectedIndex;
            ModificarCliente ventana = new ModificarCliente(coleccionVM.ListaClientes[pos], coleccionVM);
            ventana.ShowDialog();
        }

        private void Eliminar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult resp = (DialogResult)System.Windows.MessageBox.Show("¿Deseas borrar el elemento seleccionado?", "Borrar Cliente", MessageBoxButton.YesNo, (MessageBoxImage)MessageBoxIcon.Information);
            int pos = lstClientes.SelectedIndex;
            clientes objCliente = (clientes)lstClientes.SelectedItem;
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                if(objCliente.pedidos.Count > 0)
                {
                    DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("Si elimina el cliente tambien eliminará sus pedidos ¿Quiere borrar todo?", "Eliminar medico", MessageBoxButton.YesNo);
                    if(dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        while(objCliente.pedidos.Count > 0)
                        {
                            var pedido = (pedidos)objCliente.pedidos.First();
                            coleccionVM.objBD.pedidos.Remove(pedido);
                        }
                        //Ahora lo eliminamos de la BBDD
                        coleccionVM.objBD.clientes.Remove((clientes)lstClientes.SelectedItem);
                        //Lo eliminamos de la lista del collection view model
                        coleccionVM.ListaClientes.RemoveAt(lstClientes.SelectedIndex);
                        System.Windows.Forms.MessageBox.Show("Cliente eliminado correctamente...", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                else
                {
                     //Ahora lo eliminamos de la BBDD
                        coleccionVM.objBD.clientes.Remove((clientes)lstClientes.SelectedItem);
                        //Lo eliminamos de la lista del collection view model
                        coleccionVM.ListaClientes.RemoveAt(lstClientes.SelectedIndex);
                        System.Windows.Forms.MessageBox.Show("Cliente eliminado correctamente...", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            }

        private void GuardarBBDD_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            coleccionVM.guardarDatos();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }
    }
}
