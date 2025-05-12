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
using FutbolAdmin.ViewModel;
using FutbolAdmin.ViewModel.Visitantes;

namespace FutbolAdmin.View.Visitantes {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        protected MainWindowViewModel _viewModel;

        public MainWindow() {
            DataContext = new MainWindowViewModel();

            InitializeComponent();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new LoginWindow(), this);
        }

        private void VerPartidosButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ShowWindowAndHideParent(new ConsultarResultadosWindow(), this);
        }

        private void ClasificacionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClasificacionDataGrid.SelectedItem is EquipoModel equipoSeleccionado)
            {
                int idEquipo = equipoSeleccionado.Id_Equipo;

                // Abre la ventana con el ID del equipo como parámetro
                NavigationHelper.ShowWindowAndHideParent(new ConsultarEquiposWindow(idEquipo), this);
            }
        }
    }
}
