using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SgEntregasAlvaroChema
{
    class Comandos
    {
        //Comandos ventana principal

        public static readonly RoutedUICommand Salir = new RoutedUICommand(
            "Cerrar la aplicación",
            "Salir",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Escape)
            }
       );

        //Comandos ventana Gestión de Clientes vista ordenador
        public static readonly RoutedUICommand Add = new RoutedUICommand(
           "Accion cuando se añade algo",
           "Añadir",
           typeof(MainWindow),
           new InputGestureCollection()
           {
                new KeyGesture(Key.F1)
           }
      );

        public static readonly RoutedUICommand Modificar = new RoutedUICommand(
            "Accion cuando se modificar algo",
            "Modificar",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F2)
            }
       );
        public static readonly RoutedUICommand Eliminar = new RoutedUICommand(
            "Accion cuando se elimina algo",
            "Eliminar",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F3)
            }
       );
        public static readonly RoutedUICommand Guardar = new RoutedUICommand(
            "Accion cuando se guarda en la BBDD",
            "Guardar",
            typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4)
            }
       );
    }
}
