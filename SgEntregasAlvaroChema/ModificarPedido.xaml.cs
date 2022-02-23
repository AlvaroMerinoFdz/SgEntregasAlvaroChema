using SgEntregasAlvaroChema.viewModel;
using System;
using System.Windows;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para ModificarPedido.xaml
    /// </summary>
    public partial class ModificarPedido : Window
    {
        pedidos pedido;
        pedidos copiaPedido;
        CollectionViewModel coleccionVM;
        GestionPedidos ventanaAnterior;
        public ModificarPedido(pedidos pedido, CollectionViewModel colectionVM, GestionPedidos ventanaAnterior)
        {
            InitializeComponent();
            this.pedido = pedido;

            copiaPedido = (pedidos)pedido.Clone();
            this.DataContext = copiaPedido;
            this.coleccionVM = colectionVM;
            this.ventanaAnterior = ventanaAnterior;

            cargarDatos();
        }

        private void cargarDatos()
        {
            dtp_fecha_pedido.BlackoutDates.AddDatesInPast();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (this.txt_descripcion.Text.Trim() == "" || this.dtp_fecha_pedido.SelectedDate == null)
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                pedido.fecha_pedido = copiaPedido.fecha_pedido;
                pedido.descripcion = copiaPedido.descripcion;
                MessageBox.Show("Pedido modificado correctamente", "Pedido modificado.");

                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }
    }
}
