//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SgEntregasAlvaroChema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class clientes : INotifyPropertyChanged, ICloneable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            this.pedidos = new HashSet<pedidos>();
        }
        //public string dni { get; set; }
        private string _dni;

        public string dni
        {
            get { return _dni; }
            set { _dni = value; notificarPropertyChanged();
            }
        }

        
        //public string nombre { get; set; }
        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; notificarPropertyChanged();
            }
        }

        //public string apellidos { get; set; }
        private string _apellidos;

        public string apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; notificarPropertyChanged();
            }
        }

        //public string email { get; set; }
        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; notificarPropertyChanged();
            }
        }

        //public string domicilio { get; set; }
        private string _domicilio;

        public string domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; notificarPropertyChanged();
            }
        }

        //public string localidad { get; set; }
        private string _localidad;

        public string localidad
        {
            get { return _localidad; }
            set { _localidad = value; notificarPropertyChanged();
            }
        }

        //public int provincia { get; set; }
        private int _provincia;

        public int provincia
        {
            get { return _provincia; }
            set { _provincia = value; notificarPropertyChanged();
            }
        }

        //public virtual provincias provincias { get; set; }
        private provincias _provincias;

        public virtual provincias provincias
        {
            get { return _provincias; }
            set { _provincias = value; notificarPropertyChanged();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<pedidos> pedidos { get; set; }
        private ICollection<pedidos> _pedidos;

        public virtual ICollection<pedidos> pedidos
        {
            get { return _pedidos; }
            set { _pedidos = value;
                notificarPropertyChanged();
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
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
