using Microsoft.Win32;
using SgEntregasAlvaroChema.UsersCards;
using SgEntregasAlvaroChema.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;

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
        List<pedidos> listaPedidos = new List<pedidos>();
        private VentanaTactil ventanaAnterior;

        public VentanaPedidosClientesTactil(clientes client)
        {
            InitializeComponent();

            this.clienteActual = client;
            this.cvm = (CollectionViewModel)((ObjectDataProvider)this.Resources["CollectionViewModel"]).ObjectInstance;
            //this.cvm = new CollectionViewModel(clienteActual);

            comprobarOrientacion();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;

        }

        public VentanaPedidosClientesTactil(clientes client, CollectionViewModel cvm, VentanaTactil ventanaAnterior)
        {
            InitializeComponent();

            this.clienteActual = client;
            this.cvm = cvm;

            cargarPedidosCliente();
            this.ventanaAnterior = ventanaAnterior;
        }

        private void cargarPedidosCliente()
        {
            

            var query = from p in cvm.objBD.pedidos
                        where p.cliente == this.clienteActual.dni && p.fecha_entrega == null
                        select p;
            
            listaPedidos = query.ToList();

            pintarCards(listaPedidos);

        }

        private void pintarCards(List<pedidos> lista)
        {
            this.sp_card_list.Children.Clear();
            foreach (pedidos p in lista)
            {
                UserControlPedidos ucp = new UserControlPedidos(cvm, p,this);

                ucp.Id_Pedido = p.id_pedido;
                ucp.Descripcion = p.descripcion;
                ucp.Fecha_Pedido = p.fecha_pedido;

                this.sp_card_list.Children.Add(ucp);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            cargarPedidosCliente();
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            comprobarOrientacion();
        }

        private void comprobarOrientacion()
        {

            if (SystemParameters.PrimaryScreenWidth > SystemParameters.PrimaryScreenHeight)
            {
                sp_card_list.Orientation = System.Windows.Controls.Orientation.Horizontal;
                this.Height = SystemParameters.PrimaryScreenHeight;
                this.Width = SystemParameters.PrimaryScreenWidth;
            }
            else
            {
                sp_card_list.Orientation = System.Windows.Controls.Orientation.Vertical;
                this.Height = SystemParameters.PrimaryScreenHeight;
                this.Width = SystemParameters.PrimaryScreenWidth;
            }
        }
    }
}
