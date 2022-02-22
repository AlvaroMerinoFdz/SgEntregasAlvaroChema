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
    /// Lógica de interacción para AddPedido.xaml
    /// </summary>
    public partial class AddPedido : Window
    {
        CollectionViewModel coleccionVM;
        List<String> clientesList;
        clientes cliente;
        GestionPedidos ventanaAnterior;
        public AddPedido(CollectionViewModel coleccionVM, clientes cliente , GestionPedidos ventanaAnterior)
        {
            InitializeComponent();
            clientesList = new List<String>();
            this.coleccionVM = coleccionVM;
            this.cliente = cliente;
            cargarDatos();
            this.ventanaAnterior = ventanaAnterior;
        }

        private void cargarDatos()
        {
            this.cmb_cliente.Items.Clear();
            foreach(var cli in coleccionVM.ListaClientes)
            {
                cmb_cliente.Items.Add(cli.nombre);
                clientesList.Add(cli.dni);
            }
            this.cmb_cliente.SelectedItem = cliente.nombre;

            //Con esto evitamos que se pueda seleccionar una fecha que no sea la de hoy.
            dtp_fecha_pedido.BlackoutDates.AddDatesInPast();

        }

        private void btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
            pedidos pedido = new pedidos();
            pedido.cliente = clientesList[cmb_cliente.SelectedIndex];
            pedido.fecha_pedido = (DateTime)dtp_fecha_pedido.SelectedDate;
            pedido.descripcion = txt_descripcion.Text.ToString();

            //Agregamos también la referencia al objeto
            pedido.clientes = coleccionVM.ListaClientes[cmb_cliente.SelectedIndex];

            if(this.txt_descripcion.Text.Trim() == "" || this.dtp_fecha_pedido.SelectedDate == null)
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                //Lo guardamos en la lista de la tabla de clientes de la base de datos
                coleccionVM.objBD.pedidos.Add(pedido);
                //Lo guardamos en la lista observable
                coleccionVM.ListaPedidos.Add(pedido);
                //Cerramos la ventana de añadir.
                MessageBox.Show("Pedido añadido correctamente.", "Pedido añadido");
                this.Close();
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }
    }
}
