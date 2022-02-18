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
    /// Lógica de interacción para VentanaFirma.xaml
    /// </summary>
    public partial class VentanaFirma : Window
    {
        private int id_pedido;
        private CollectionViewModel cvm;

        public VentanaFirma(int id_pedido, CollectionViewModel cvm)
        {
            InitializeComponent();

            this.id_pedido = id_pedido;
            this.cvm = cvm;
            lbl_id_pedido.Content = (id_pedido.ToString());

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
            
        }
    }
}
