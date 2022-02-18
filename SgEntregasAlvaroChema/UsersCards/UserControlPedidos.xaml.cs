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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SgEntregasAlvaroChema.UsersCards
{
    /// <summary>
    /// Lógica de interacción para UserControlPedidos.xaml
    /// </summary>
    public partial class UserControlPedidos : UserControl
    {
        public static readonly DependencyProperty Id_PedidoProperty = DependencyProperty.Register("id_pedido", typeof(int), typeof(UserControlPedidos), new PropertyMetadata(0));

        public static readonly DependencyProperty DescripcionProperty = DependencyProperty.Register("descripcion", typeof(string), typeof(UserControlPedidos), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty Fecha_PedidoProperty = DependencyProperty.Register("fecha_pedido", typeof(DateTime), typeof(UserControlPedidos), new PropertyMetadata(new DateTime()));

        CollectionViewModel cvm;

        
        public UserControlPedidos(CollectionViewModel cvm)
        {
            InitializeComponent();

            this.cvm = cvm;
            this.MouseLeftButtonUp += UserControlPedidos_MouseLeftButtonUp;
            this.TouchDown += UserControlPedidos_TouchDown;
        }

        private void UserControlPedidos_TouchDown(object sender, TouchEventArgs e)
        {
            VentanaFirma winFirm = new VentanaFirma(Id_Pedido, cvm);
            winFirm.ShowDialog();
            e.Handled = true;
        }

        private void UserControlPedidos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VentanaFirma winFirm = new VentanaFirma(Id_Pedido, cvm);
            winFirm.ShowDialog();
            e.Handled = true;
        }



        public int Id_Pedido 
        {
            get { return (int)GetValue(Id_PedidoProperty); }
            set { SetValue(Id_PedidoProperty, value); }
        }

        public string Descripcion 
        {
            get { return (string)GetValue(DescripcionProperty); }
            set { SetValue(DescripcionProperty, value); }
        }

        public DateTime Fecha_Pedido 
        {
            get { return (DateTime)GetValue(Fecha_PedidoProperty); }
            set { SetValue(Fecha_PedidoProperty, value); }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("sdkjhsajhgsa");
            VentanaFirma winFirm = new VentanaFirma(Id_Pedido, cvm);
            winFirm.ShowDialog();
            e.Handled = true;
        }

        private void Border_TouchDown(object sender, TouchEventArgs e)
        {
            VentanaFirma winFirm = new VentanaFirma(Id_Pedido, cvm);
            winFirm.ShowDialog();
            e.Handled = true;
        }

        private void btn_firmar_Click(object sender, RoutedEventArgs e)
        {
            VentanaFirma winFirm = new VentanaFirma(Id_Pedido, cvm);
            winFirm.ShowDialog();
            e.Handled = true;
        }

        //private void Border_MouseDown(object sender, MouseButtonEventArgs e) 
        //{
        //    VentanaFirma winFirm = new VentanaFirma(Id_Pedido, cvm);
        //    winFirm.ShowDialog();
        //}
    }
}
