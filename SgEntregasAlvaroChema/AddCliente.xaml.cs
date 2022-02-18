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
    /// Lógica de interacción para AddCliente.xaml
    /// </summary>
    public partial class AddCliente : Window
    {
        CollectionViewModel coleccionVM;
        public AddCliente(CollectionViewModel colectionVM)
        {
            InitializeComponent();
            this.coleccionVM = colectionVM;
            cargarProvincias();
        }

        private void cargarProvincias()
        {
            this.cmb_provincia.Items.Clear();
            foreach (var provi in coleccionVM.ListaProvincias)
            {
                cmb_provincia.Items.Add(provi.nombre_provincia);
            }
            cmb_provincia.SelectedIndex = 0;
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
            clientes cliente = new clientes();
            cliente.dni = txt_dni.Text.ToString();
            cliente.nombre = txt_nombre.Text.ToString();
            cliente.apellidos = txt_apellidos.Text.ToString();
            cliente.email = txt_email.Text.ToString();
            cliente.domicilio = txt_domicilio.Text.ToString();
            cliente.localidad = txt_localidad.Text.ToString();
            cliente.provincia = cmb_provincia.SelectedIndex;

            //también añadiremos la referencia al otro objeto
            cliente.provincias = coleccionVM.ListaProvincias[cmb_provincia.SelectedIndex];

            bool correcto = true;

            if (this.txt_dni.Text.Trim() == "" || this.txt_nombre.Text.Trim() == "" || this.txt_apellidos.Text.Trim() == ""
                || this.txt_email.Text.Trim() == "" || this.txt_localidad.Text.Trim() == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                foreach (var cli in coleccionVM.ListaClientes)
                {
                    if(cli.dni == txt_dni.Text)
                    {
                        correcto = false;
                    }
                }
                if (correcto)
                {
                    //Lo guardamos en la lista de la tabla de clientes de la base de datos
                    coleccionVM.objBD.clientes.Add(cliente);
                    //Lo guardamos en la lista observable
                    coleccionVM.ListaClientes.Add(cliente);
                    //Cerramos la ventana de añadir.
                    MessageBox.Show("Cliente añadido correctamente.", "Cliente añadido");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("DNI ya existente.", "Error añadido", MessageBoxButton.OK);

                }
            }
        }
    }
}
