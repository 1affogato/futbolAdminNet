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
using FutbolAdmin.Model;
using FutbolAdmin.View.Crud.Jugador.ventanasSecundarias;

namespace FutbolAdmin.View.Crud.Jugador {
    /// <summary>
    /// Interaction logic for ModificarJugadorWindow.xaml
    /// </summary>
    public partial class ModificarJugadorWindow : Window {
        public ModificarJugadorWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            NavigationHelper.CloseWindow(this);
        }

        private void JugadoresDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (JugadoresDataGrid.SelectedItem is JugadorModel jugadorSeleccionado) {
                NavigationHelper.ShowWindowAndHideParent(new EditarJugadorWindow(jugadorSeleccionado), this);
            }
        }
    }
}
