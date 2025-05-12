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
using FutbolAdmin.View.Crud.Equipo;

namespace FutbolAdmin.View.Crud.Jugador {
    /// <summary>
    /// Interaction logic for CrudJugadorWindow.xaml
    /// </summary>
    public partial class CrudJugadorWindow : Window {
        public CrudJugadorWindow() {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void ModificarJugadorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new ModificarJugadorWindow(), this);
        }

        private void CrearJugadorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new CrearJugadorWindow(), this);
        }

        private void EliminarJugadorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new EliminarJugadorWindow(), this);
        }

        private void ConsultarJugadorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new ConsultarJugadorWindow(), this);
        }
    }
}
