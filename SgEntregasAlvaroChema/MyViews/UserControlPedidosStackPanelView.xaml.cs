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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SgEntregasAlvaroChema.MyViews
{
    /// <summary>
    /// Lógica de interacción para UserControlPedidosStackPanelView.xaml
    /// </summary>
    public partial class UserControlPedidosStackPanelView : UserControl
    {
        public UserControlPedidosStackPanelView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //VentanaFirma winFirm = new VentanaFirma(1);
            //winFirm.ShowDialog();
        }

        private void btn_firmar_Click(object sender, RoutedEventArgs e)
        {
            //VentanaFirma winFirm = new VentanaFirma(1);
            //winFirm.ShowDialog();

        }
    }
}
