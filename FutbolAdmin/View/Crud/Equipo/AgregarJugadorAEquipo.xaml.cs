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

namespace FutbolAdmin.View.Crud.Equipo {
    /// <summary>
    /// Interaction logic for AgregarJugadorAEquipo.xaml
    /// </summary>
    public partial class AgregarJugadorAEquipo : Window {
        public AgregarJugadorAEquipo() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void SeleccionarJugadorButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationHelper.ShowWindowAndHideParent(SeleccionarJugadorExistenteWindow(),this);
        }
    }
}
