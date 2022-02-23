using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SgEntregasAlvaroChema.MyViews
{
    /// <summary>
    /// Lógica de interacción para UserControlPedidosStackPanelView.xaml
    /// </summary>
    public partial class UserControlPedidosStackPanelView : UserControl
    {
        public UserControlPedidosStackPanelView()
        {
            InitializeComponent();
            comprobarOrientacion();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }


        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            comprobarOrientacion();
        }

        private void comprobarOrientacion()
        {

            if (SystemParameters.PrimaryScreenWidth > SystemParameters.PrimaryScreenHeight)
            {
                contenderCards.Orientation = Orientation.Vertical;
            }
            else
            {
                contenderCards.Orientation = Orientation.Horizontal;
            }
        }
    }
}
