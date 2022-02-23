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
    /// Lógica de interacción para ModificarCliente.xaml
    /// </summary>
    public partial class ModificarCliente : Window
    {
        clientes cliente;
        clientes copiaCliente;
        CollectionViewModel coleccionVM;
        List<int> provinciasList = new List<int>();
        GestionClientes ventanaAnterior;
        public ModificarCliente(clientes cliente, CollectionViewModel coleccionVM, GestionClientes ventanaAnterior)
        {
            InitializeComponent();
            this.cliente = cliente;

            copiaCliente = (clientes)cliente.Clone();
            this.DataContext = copiaCliente;
            this.coleccionVM = coleccionVM;
            this.ventanaAnterior = ventanaAnterior;

            cargarProvincias();
        }

        private void cargarProvincias()
        {
            this.cmb_provincia.Items.Clear();
            foreach (var provi in coleccionVM.ListaProvincias)
            {
                cmb_provincia.Items.Add(provi.nombre_provincia);
                provinciasList.Add(provi.id_provincia);
            }
            //Con esto cargamos la provincia adecuada
           /* int pos = 0;
            int i = 0;
            for (i=0; i < provinciasList.Count; i++)
            {
                if(provinciasList[i] == cliente.provincia)
                {
                    pos = i;
                }
            }
            cmb_provincia.SelectedIndex = i;*/
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (this.txt_dni.Text.Trim() == "" || this.txt_nombre.Text.Trim() == "" || this.txt_apellidos.Text.Trim() == ""
                || this.txt_email.Text.Trim() == "" || this.txt_localidad.Text.Trim() == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                cliente.dni = copiaCliente.dni;
                cliente.nombre = copiaCliente.nombre;
                cliente.apellidos = copiaCliente.apellidos;
                cliente.email = copiaCliente.email;
                cliente.domicilio = copiaCliente.domicilio;
                cliente.localidad = copiaCliente.localidad;
                cliente.provincia = copiaCliente.provincia  + 1 ;

                MessageBox.Show("Cliente modificado correctamente", "Cliente modificado.");

                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ventanaAnterior.Visibility = Visibility.Visible;
        }
    }
}
