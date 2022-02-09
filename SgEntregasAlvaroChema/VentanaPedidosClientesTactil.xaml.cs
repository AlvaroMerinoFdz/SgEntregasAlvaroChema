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
    /// Lógica de interacción para VentanaPedidosClientesTactil.xaml
    /// </summary>
    public partial class VentanaPedidosClientesTactil : Window
    {
        CollectionViewModel cvm;
        clientes clienteActual;
        clientes clienteCopia;

        public VentanaPedidosClientesTactil(clientes client, CollectionViewModel cvm)
        {
            InitializeComponent();

            this.clienteActual = client;
            this.cvm = cvm;
        }
    }
}
