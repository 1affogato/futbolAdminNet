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
using FutbolAdmin.View.Crud.Jugador;

namespace FutbolAdmin.View.Crud {
    /// <summary>
    /// Interaction logic for CatalogosCrudWindow.xaml
    /// </summary>
    public partial class CatalogosCrudWindow : Window {
        public CatalogosCrudWindow() {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.CloseWindow(this);
        }

        private void GestionarEquipoButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new CrudEquipoWIndow(), this);
        }

        private void GestionarJugadoresButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new CrudJugadorWindow(), this);
        }
    }
}
