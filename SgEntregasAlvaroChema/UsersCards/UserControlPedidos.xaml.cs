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

        public UserControlPedidos()
        {
            InitializeComponent();
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
    }
}
