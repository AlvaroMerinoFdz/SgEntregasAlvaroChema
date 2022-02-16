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
using SgEntregasAlvaroChema.UsersCards;
using SgEntregasAlvaroChema.viewModel;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para VentanaPedidosClientesTactil.xaml
    /// </summary>
    public partial class VentanaPedidosClientesTactil : Window
    {
        
        clientes clienteActual;
        clientes clienteCopia;
        CollectionViewModel cvm;

        public VentanaPedidosClientesTactil(clientes client)
        {
            InitializeComponent();

            this.clienteActual = client;
            this.cvm = (CollectionViewModel)((ObjectDataProvider)this.Resources["CollectionViewModel"]).ObjectInstance;
            //this.cvm = new CollectionViewModel(clienteActual);
            
        }

        public VentanaPedidosClientesTactil(clientes client, CollectionViewModel cvm) 
        {
            InitializeComponent();

            this.clienteActual = client;
            this.cvm = cvm;

            cargarPedidosCliente();
        }

        private void cargarPedidosCliente() 
        {
            using (entregasEntities objBD = new entregasEntities()) 
            {
            
                var query = from p in objBD.pedidos
                            where p.cliente == this.clienteActual.dni
                            select p;

                var lista = query.ToList();

                pintarCards(lista);
            }
        }

        private void pintarCards(List<pedidos> lista) 
        {
            
            foreach ( pedidos p in lista) 
            {
                UserControlPedidos ucp = new UserControlPedidos();

                ucp.Id_Pedido = p.id_pedido;
                ucp.Descripcion = p.descripcion;
                ucp.Fecha_Pedido = p.fecha_pedido;

                this.sp_card_list.Children.Add(ucp);
            }
        }
    }
}
