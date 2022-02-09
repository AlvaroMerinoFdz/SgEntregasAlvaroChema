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
    /// Lógica de interacción para GestionClientes.xaml
    /// </summary>
    public partial class GestionClientes : Window
    {
        private CollectionViewModel coleccionVM;
        public GestionClientes()
        {
            InitializeComponent();
            coleccionVM = (CollectionViewModel)this.Resources["ColeccionVM"];
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

        }

        private void Eliminar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            coleccionVM.ListaClientes.Remove((clientes)lstClientes.SelectedItem);
        }

        private void GuardarBBDD_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            coleccionVM.guardarDatos();
        }
    }
}
