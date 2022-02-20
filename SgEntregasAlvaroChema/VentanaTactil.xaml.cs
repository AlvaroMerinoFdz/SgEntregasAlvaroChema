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

        public VentanaTactil()
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["CollectionVmVentanaTactil"];
        }

     

        private void lista_clientes_ventana_tactil_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            int pos = lista_clientes_ventana_tactil.SelectedIndex;
            VentanaPedidosClientesTactil windPed = new VentanaPedidosClientesTactil(cvm.ListaClientes[pos],cvm);
            windPed.ShowDialog();
        }

    }
}
