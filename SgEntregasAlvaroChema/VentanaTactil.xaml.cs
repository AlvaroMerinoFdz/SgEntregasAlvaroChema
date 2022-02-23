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
using SgEntregasAlvaroChema.viewModel;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para VentanaTactil.xaml
    /// </summary>
    public partial class VentanaTactil : Window
    {
        CollectionViewModel cvm;
        private MainWindow ventanaAnterior;

        public VentanaTactil(MainWindow ventana)
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["CollectionVmVentanaTactil"];
            this.ventanaAnterior = ventana;
        }

     

        private void lista_clientes_ventana_tactil_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            int pos = lista_clientes_ventana_tactil.SelectedIndex;
            VentanaPedidosClientesTactil windPed = new VentanaPedidosClientesTactil(cvm.ListaClientes[pos],cvm,this);
            this.Visibility = Visibility.Hidden;
            windPed.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }
    }
}
