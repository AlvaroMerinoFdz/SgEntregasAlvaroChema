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
    /// Lógica de interacción para VentanaOrdenador.xaml
    /// </summary>
    public partial class VentanaOrdenador : Window
    {
        public VentanaOrdenador()
        {
            InitializeComponent();
        }

        private void btn_gestion_clientes_Click(object sender, RoutedEventArgs e)
        {
            GestionClientes ventana = new GestionClientes();
            ventana.ShowDialog();
        }

        private void btn_gestion_pedidos_Click(object sender, RoutedEventArgs e)
        {
            GestionPedidos ventana = new GestionPedidos();
            ventana.ShowDialog();
        }
    }
}
