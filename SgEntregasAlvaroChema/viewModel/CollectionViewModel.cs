using SgEntregasAlvaroChema.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SgEntregasAlvaroChema.viewModel
{
    public class CollectionViewModel : INotifyPropertyChanged
    {

        public CollectionViewModel()
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            //Cargamos los clientes
            ListaClientes.Clear();
            var qClientes = from cli in objBD.clientes select cli;
            foreach (var client in qClientes.ToList())
            {
                ListaClientes.Add(client);
            }

            //Cargamos las provincias
            ListaProvincias.Clear();
            var qProvincias = from prov in objBD.provincias select prov;
            foreach (var provi in qProvincias.ToList())
            {
                ListaProvincias.Add(provi);
            }

            //Cargamos los pedidos
            ListaPedidos.Clear();
            var qPedidos = from ped in objBD.pedidos select ped;
            foreach (var pedi in qPedidos.ToList())
            {
                ListaPedidos.Add(pedi);
            }
        }

        public void cargarPedidosCliente(string dni)
        {
            ListaPedidos.Clear();
            var qPedidos = from ped in objBD.pedidos where ped.cliente == dni select ped;
            foreach (var pedi in qPedidos.ToList())
            {
                ListaPedidos.Add(pedi);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void notificarPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private entregasEntities _objBD = new entregasEntities();

        public entregasEntities objBD
        {
            get { return _objBD; }
            set
            {
                _objBD = value;
                notificarPropertyChanged();
            }
        }

        private ClienteCollection _listaClientes = new ClienteCollection();

        public ClienteCollection ListaClientes
        {
            get { return _listaClientes; }
            set
            {
                _listaClientes = value;
                notificarPropertyChanged();
            }
        }

        private ProvinciaCollection _listaProvincias = new ProvinciaCollection();

        public ProvinciaCollection ListaProvincias
        {
            get { return _listaProvincias; }
            set { _listaProvincias  = value;
                notificarPropertyChanged();
            }
        }
        private PedidoCollection _listaPedidos = new PedidoCollection();

        public PedidoCollection ListaPedidos
        {
            get { return _listaPedidos; }
            set
            {
                _listaPedidos = value;
                notificarPropertyChanged();
            }
        }



        public void guardarDatos()
        {
            objBD.SaveChanges();
            System.Windows.MessageBox.Show("Base de Datos actualizada correctamente...", "BBDD actualizada");
        }
    }
}
