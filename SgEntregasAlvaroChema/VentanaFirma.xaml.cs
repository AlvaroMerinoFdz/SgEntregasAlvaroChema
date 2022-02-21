using SgEntregasAlvaroChema.viewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SgEntregasAlvaroChema
{
    /// <summary>
    /// Lógica de interacción para VentanaFirma.xaml
    /// </summary>
    public partial class VentanaFirma : Window
    {
        private int id_pedido;
        private CollectionViewModel cvm;
        private pedidos pedidoActual;
        private pedidos pedidoCopia;
        private VentanaPedidosClientesTactil ventanaAnterior;

        public VentanaFirma(int id_pedido, CollectionViewModel cvm, pedidos ped, VentanaPedidosClientesTactil ventanaAnterior)
        {
            InitializeComponent();

            this.id_pedido = id_pedido;
            this.cvm = cvm;
            lbl_id_pedido.Content = (id_pedido.ToString());

            this.pedidoActual = ped;
            this.pedidoCopia = (pedidos)ped.Clone();
            this.ventanaAnterior = ventanaAnterior;

        }

        private void check_ejecuta_aceptar_firma(object sender, CanExecuteRoutedEventArgs e)
        {
            if (btn_aceptar_firma != null && firmaCanvas.Strokes.Count > 0) 
            { 
                e.CanExecute = true; 
            }
        }

        private void ejecuta_aceptar_firma(object sender, ExecutedRoutedEventArgs e)
        {
            guardar_firma_bd();
        }

        private void check_ejecuta_limpiar_firma(object sender, CanExecuteRoutedEventArgs e)
        {
            if (btn_limpiar_firma != null && firmaCanvas.Strokes.Count > 0)
            {
                e.CanExecute = true;
            }
        }

        private void ejecuta_limpiar_firma(object sender, ExecutedRoutedEventArgs e)
        {
            firmaCanvas.Strokes.Clear();
        }

        private void guardar_firma_bd() 
        {
            DateTime fechaActual = DateTime.Today;
            byte[] firma = InkCanvasToByte(firmaCanvas);

            pedidoCopia.fecha_entrega = fechaActual;
            pedidoCopia.firma = firma;

            pedidoActual.fecha_entrega = pedidoCopia.fecha_entrega;
            pedidoActual.firma = pedidoCopia.firma;

            System.Windows.Forms.MessageBox.Show("Pedido entregado con éxito.");

            cvm.guardarDatos();
            this.Close();
        }

        private void btn_cancelar_firma_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private byte[] InkCanvasToByte(InkCanvas canvas)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (canvas.Strokes.Count > 0)
                {
                    canvas.Strokes.Save(ms, true);
                    byte[] unencryptedSignature = ms.ToArray();
                    return unencryptedSignature;
                }
                else
                {
                    return null;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }
    }
}
